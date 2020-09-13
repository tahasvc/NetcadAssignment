//# sourceURL=map-control.js
if (window.mapControl_Loaded == null) {
    var map;
    var mapControl = {
        init: function (data) {
            mapControl.loadMap();
        },
        loadMap: function () {
            mapboxgl.accessToken = 'pk.eyJ1IjoidGFoYXN2YyIsImEiOiJjamNnNDhqNzUybG1oMndsbDM4eTF4MmxwIn0.UE2seOqNf38Yn2wSs0oTqw';
            map = new mapboxgl.Map({
                container: 'map',
                style: 'mapbox://styles/mapbox/streets-v11',
                center: [35, 39], // starting position [lng, lat]
                zoom: 5 // starting zoom

            });
            map.addControl(new mapboxgl.FullscreenControl()); //fullscreencontrol
            map.on('load', function () {
                map.getCanvas().addEventListener(
                    'keydown',
                    function (e) {
                        e.preventDefault();
                        // Key 'S' listener (square)
                        if (e.which === 83) {
                            util.ajax.request("Map", "DrawSquare", mapControl.drawPoly, true);
                        }
                        // Key 'T' listener (triangle)
                        else if (e.which === 84) {
                            util.ajax.request("Map", "DrawTriangle", mapControl.drawPoly, true);
                        }
                        // Key 'C' listener (circle)
                        else if (e.which === 67) {
                            util.ajax.request("Map", "DrawCircle", mapControl.drawCircle, true);
                        }
                        // Key 'E' listener (ellipse)
                        else if (e.which === 69) {
                            util.ajax.request("Map", "DrawEllipse", mapControl.drawPoly, true);
                        }
                    },
                    true
                );
            });
            $(".mapboxgl-canvas").focus()
        },

        /**
        * draw a random circle from geojson
        * @public
        * @param {object} response geojson object
        */
        drawCircle: function (response) {//draw a random circle from geojson
            var point = JSON.parse(response)
            var guid = util.guid.createGuid()
            var geojson = {
                "type": "FeatureCollection",
                "features": [
                    {
                        "type": "Feature",
                        "properties": point.properties,
                        "geometry": {
                            "type": point.type,
                            "coordinates": point.coordinates
                        }
                    }
                ]
            }
            map.addSource(guid, {
                "type": "geojson",
                "data": geojson
            });
            map.addLayer({
                id: guid,
                type: 'circle',
                source: guid,
                paint: {
                    'circle-radius': ['/', ['-', 1000, 200], 10],
                    'circle-opacity': ["get", "fill-opacity"],
                    'circle-color': ["get", "fill"],
                    'circle-stroke-width': ["get", "stroke-width"],
                    'circle-stroke-color': ["get", "stroke"]
                }
            });
            var bbox = turf.extent(geojson);
            mapControl.fitBounds(bbox)
        },

        /**
        * draw a random polygon from geojson
        * @public
        * @param {object} response geojson object
        */
        drawPoly: function (response) {
            var poly = JSON.parse(response)
            var guid = util.guid.createGuid()
            var geojson = {
                "type": "FeatureCollection",
                "features": [
                    {
                        "type": "Feature",
                        "properties": poly.properties,
                        "geometry": {
                            "type": poly.type,
                            "coordinates": poly.coordinates
                        }
                    }
                ]
            }
            map.addSource(guid, {
                "type": "geojson",
                "data": geojson
            });
            map.addLayer({
                "id": guid,
                "type": "fill",
                "source": guid,
                paint: {
                    "fill-color": ["get", "fill"],
                    "fill-opacity": ["get", "fill-opacity"]
                }
            });
            map.addLayer({
                'id': util.guid.createGuid(),
                'type': 'line',
                'source': {
                    'type': 'geojson',
                    'data': geojson
                },
                paint: {
                    'line-color': ["get", "stroke"],
                    'line-width': ["get", "stroke-width"],
                    'line-opacity': ["get", "stroke-opactiy"]
                }
            });
            var bbox = turf.extent(geojson);
            mapControl.fitBounds(bbox)
        },

        /**
        * to fit the incoming geometry for the drawing to the limits
        * @public
        * @param {double} bounds
        * @param {int} padding 
        */
        fitBounds: function (bounds, padding = 20) {
            map.fitBounds(bounds, {
                padding: padding,
            });
        }
    }
    window.mapControl_Loaded = true;
};
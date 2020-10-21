using BruTile;
using BruTile.Predefined;
using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using NetTopologySuite;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using SharpMap;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;
using SharpMap.Rendering.Symbolizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpMapSample
{
    public partial class Form1 : Form
    {
        private static ICoordinateTransformation _wgs84ToGoogle;
        private static ICoordinateTransformation _googletowgs84;

        public Form1()
        {
            var gss = new NtsGeometryServices();
            var css = new SharpMap.CoordinateSystems.CoordinateSystemServices(
                new CoordinateSystemFactory(),
                new CoordinateTransformationFactory(),
                SharpMap.Converters.WellKnownText.SpatialReference.GetAllReferenceSystems());

            GeoAPI.GeometryServiceProvider.Instance = gss;

            SharpMap.Session.Instance
                .SetGeometryServices(gss)
                .SetCoordinateSystemServices(css)
                .SetCoordinateSystemRepository(css);

            InitializeComponent();

            mapBox1.ActiveTool = MapBox.Tools.Pan;
            mapBox1.Map.SRID = 3857;

            LoadMap();
        }

        private void LoadMap()
        {
            Map map = new Map();

            ITileSource tileSource = KnownTileSources.Create(KnownTileSource.OpenStreetMap);
            TileAsyncLayer tileLayer = new TileAsyncLayer(tileSource, "Basemap");
            map.BackgroundLayer.Add(tileLayer);


            VectorLayer shpLayer = new VectorLayer("Points");
            shpLayer.DataSource = new ShapeFile("Data/indian_points.shp", true);
            shpLayer.Style.SymbolScale = 0.8f;
            shpLayer.CoordinateTransformation = Wgs84toGoogleMercator; //Here it re-projects our degree decimal data to Google mercator
            shpLayer.ReverseCoordinateTransformation = GoogleMercatorToWgs84;
            shpLayer.SRID = 4326;

            map.Layers.Add(shpLayer);

            mapBox1.Map = map;

            mapBox1.Map.ZoomToExtents();

            mapBox1.Refresh();
        }

        public static ICoordinateTransformation Wgs84toGoogleMercator
        {
            get
            {
                if (_wgs84ToGoogle == null)
                {
                    CoordinateSystemFactory csFac = new ProjNet.CoordinateSystems.CoordinateSystemFactory();
                    CoordinateTransformationFactory ctFac = new CoordinateTransformationFactory();

                    IGeographicCoordinateSystem wgs84 = csFac.CreateGeographicCoordinateSystem(
                      "WGS 84", AngularUnit.Degrees, HorizontalDatum.WGS84, PrimeMeridian.Greenwich,
                      new AxisInfo("north", AxisOrientationEnum.North), new AxisInfo("east", AxisOrientationEnum.East));

                    List<ProjectionParameter> parameters = new List<ProjectionParameter>();
                    parameters.Add(new ProjectionParameter("semi_major", 6378137.0));
                    parameters.Add(new ProjectionParameter("semi_minor", 6378137.0));
                    parameters.Add(new ProjectionParameter("latitude_of_origin", 0.0));
                    parameters.Add(new ProjectionParameter("central_meridian", 0.0));
                    parameters.Add(new ProjectionParameter("scale_factor", 1.0));
                    parameters.Add(new ProjectionParameter("false_easting", 0.0));
                    parameters.Add(new ProjectionParameter("false_northing", 0.0));
                    IProjection projection = csFac.CreateProjection("Google Mercator", "mercator_1sp", parameters);

                    IProjectedCoordinateSystem epsg900913 = csFac.CreateProjectedCoordinateSystem(
                      "Google Mercator", wgs84, projection, LinearUnit.Metre, new AxisInfo("East", AxisOrientationEnum.East),
                      new AxisInfo("North", AxisOrientationEnum.North));

                    ((CoordinateSystem)epsg900913).DefaultEnvelope = new[] { -20037508.342789, -20037508.342789, 20037508.342789, 20037508.342789 };

                    _wgs84ToGoogle = ctFac.CreateFromCoordinateSystems(wgs84, epsg900913);
                }

                return _wgs84ToGoogle;
            }
        }

        public static ICoordinateTransformation GoogleMercatorToWgs84
        {
            get
            {
                if (_googletowgs84 == null)
                {
                    CoordinateSystemFactory csFac = new ProjNet.CoordinateSystems.CoordinateSystemFactory();
                    CoordinateTransformationFactory ctFac = new CoordinateTransformationFactory();

                    IGeographicCoordinateSystem wgs84 = csFac.CreateGeographicCoordinateSystem(
                      "WGS 84", AngularUnit.Degrees, HorizontalDatum.WGS84, PrimeMeridian.Greenwich,
                      new AxisInfo("north", AxisOrientationEnum.North), new AxisInfo("east", AxisOrientationEnum.East));

                    List<ProjectionParameter> parameters = new List<ProjectionParameter>();
                    parameters.Add(new ProjectionParameter("semi_major", 6378137.0));
                    parameters.Add(new ProjectionParameter("semi_minor", 6378137.0));
                    parameters.Add(new ProjectionParameter("latitude_of_origin", 0.0));
                    parameters.Add(new ProjectionParameter("central_meridian", 0.0));
                    parameters.Add(new ProjectionParameter("scale_factor", 1.0));
                    parameters.Add(new ProjectionParameter("false_easting", 0.0));
                    parameters.Add(new ProjectionParameter("false_northing", 0.0));
                    IProjection projection = csFac.CreateProjection("Google Mercator", "mercator_1sp", parameters);

                    IProjectedCoordinateSystem epsg900913 = csFac.CreateProjectedCoordinateSystem(
                      "Google Mercator", wgs84, projection, LinearUnit.Metre, new AxisInfo("East", AxisOrientationEnum.East),
                      new AxisInfo("North", AxisOrientationEnum.North));

                    _googletowgs84 = ctFac.CreateFromCoordinateSystems(epsg900913, wgs84);
                }

                return _googletowgs84;
            }
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = MapBox.Tools.Pan;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = MapBox.Tools.ZoomIn;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = MapBox.Tools.ZoomOut;
        }

        private void btnZoomWindow_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = MapBox.Tools.ZoomWindow;
        }

        private void btnLayerExtent_Click(object sender, EventArgs e)
        {
            mapBox1.Map.ZoomToBox(mapBox1.Map.Layers.First().Envelope);
            mapBox1.Refresh();
        }
    }
}

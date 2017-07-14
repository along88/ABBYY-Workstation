using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.WorkstationModels;
using WindowsFormsApplication1.WorkstationView;
using System.Windows.Forms;
namespace WindowsFormsApplication1.WorkstationPresenter
{
    public class SearchPresenter
    {
        private readonly ISearchModel model;
        private readonly ISearchView view;
        
        
        public SearchPresenter(ISearchModel model, ISearchView view)
        {
            this.model = model;
            this.view = view;
            EventListeners();
        }

        private void EventListeners()
        {
            view.onStateChanged += UpdateGrid;
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            
            model.ControlNo = view.ControlNo;
            
            if(!string.IsNullOrWhiteSpace(model.ControlNo))
            {
                if (model.Connect())
                {
                    model.Grid = view.Grid;
                    // view.Grid = model.ReturnData(string.Format("SELECT* FROM Acord140_Critical WHERE ControlNoIMS = '{0}'",model.ControlNo));
                    view.Grid = model.ReturnData(string.Format(" SELECT ControlNoIMS AS 'Control Number', LocationNo AS 'Location Number',    BuildingNo AS 'Building Number',    StreetAddressRaw as 'Raw Street Address',    PhysicalBuildingNumber as 'Physical Building Number',    SinglePhysBuildingNumber as 'Single Physical Building Number',    Street1 as 'Street 1',    Street2 as 'Street 2',    City,    Acord140_Critical.State,    Zip,    County,	Building_Value as 'Building Value',	Business_Personal_Property as 'Business Personal Property',	Business_Income as 'Business Income',	Misc_Real_Property as 'Misc Real Property',    BldgDescription as 'Building Description',    Units as '# Units',    ConstrTypes.ConstructionType as 'Construction Type',    DistToFireHydrant as 'Distance to Fire Hydrant',    DistToFireStation as 'Distance to Fire Station',    ProtectionCode as 'Protection Code',    Stories as '# Stories',    Basements as '# Basements',    YearBuilt as 'Year Built',    SqFootage as 'Square Footage',    WiringYear as 'Wiring Year',    PlumbingYear as 'Plumbing Year',    RoofingYear as 'Roofing Year',    HeatingYear as 'Heating Year',    BurgAlarm.AlarmType as 'Burglar Alarm Type',    FireAlarm.AlarmType as 'Fire Alarm Type',    SprinkAlarm.SprinklerAlarmType as 'Sprinkler Alarm Type',    WetDry.SprinklerWetDry as 'Sprinkler Wet/Dry',    SprinkExtent.SprinklerExtent as 'Sprinkler Extent',    DateCreated as 'Date Created'from    Acord140_Critical   inner join ConstructionTypes as ConstrTypes on ConstrTypes.ConstructionTypeID = Acord140_Critical.ConstructionTypeID   inner join AlarmTypes as BurgAlarm on BurgAlarm.AlarmTypeID = Acord140_Critical.BurglarAlarmTypeID   inner join AlarmTypes as FireAlarm on FireAlarm.AlarmTypeID = Acord140_Critical.FireAlarmTypeID   inner join SprinklerAlarmType as SprinkAlarm on SprinkAlarm.SprinklerAlarmTypeID = Acord140_Critical.SprinklerAlarmTypeID   inner join SprinklerExtent as SprinkExtent on SprinkExtent.SprinklerExtentID = Acord140_Critical.SprinklerExtentID   inner join SprinklerWetDry as WetDry on WetDry.SprinklerWetDryID = Acord140_Critical.SprinklerWetDryID where   cast(ControlNoIMS as nvarchar(250)) like '%{0}%'",model.ControlNo.ToString()));
                }
                else
                {
                    MessageBox.Show(model.ErrorMessage);
                }
                
                
            }
        }

        

        

      
        

        

        
    }
}

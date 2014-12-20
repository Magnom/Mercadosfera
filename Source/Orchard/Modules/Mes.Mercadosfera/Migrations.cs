using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;


namespace Mes.Mercadosfera
{
       public class Migrations : DataMigrationImpl {
    
            public  int Create(){

                // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
                ContentDefinitionManager.AlterPartDefinition("CarouselPart", part => part
                    .Attachable());
            return 1;
        }

            public int UpdateFrom3()
            {
                ContentDefinitionManager.AlterPartDefinition("CarouselPart",
                builder => builder.WithField("CarouselImage",
                    fieldBuilder => fieldBuilder
                        .OfType("MediaPickerField")
                        .WithDisplayName("Carousel Image")));

                return 4;
            }


            public int UpdateFrom4() {
                SchemaBuilder.CreateTable("CarouselPartRecord", table => table                    
                    .ContentPartRecord()
                    .Column<int>("IdCarousel")
                    .Column<string>("UrlImage", column => column.WithLength(200))
                    .Column<string>("Texto", column => column.WithLength(200))
                    .Column<string>("Descripcion", column => column.WithLength(200))
                    .Column<string>("Datos", column => column.WithLength(4000))
                    );

                // Return the version that this feature will be after this method completes
                return 5;
            }

            public int UpdateFrom5()
            {
                ContentDefinitionManager.AlterPartDefinition("CalendarPart", part => part
                    .Attachable());

                ContentDefinitionManager.AlterPartDefinition("ProductSearchPart", part => part
                    .Attachable());


                SchemaBuilder.CreateTable("CalendarPartRecord", table => table
                    .ContentPartRecord()
                    .Column<int>("IdCalendar")                    
                    );

                // Return the version that this feature will be after this method completes
                return 6;
            }
            public int UpdateFrom6()
            {
              /*  ContentDefinitionManager.AlterPartDefinition("CarouselPart", part => part
                    .Attachable());
                */
                ContentDefinitionManager.AlterPartDefinition("ProductChartPart", part => part
                    .Attachable());                

                ContentDefinitionManager.AlterPartDefinition("SearchInputPart", part => part
                    .Attachable());                

                return 7;
            }

            public int UpdateFrom10()
            {
              
                ContentDefinitionManager.AlterPartDefinition("SearchResultPart", part => part
                    .Attachable());
                /*
                SchemaBuilder.CreateTable("SearchResultRecord", table => table
                    .ContentPartRecord()                    
                    .Column<string>("webserviceURL", column => column.WithLength(200))                    
                    );
                */
                return 11;
            }

            public int UpdateFrom11()
            {

                ContentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                    .Attachable());
                /*
                SchemaBuilder.CreateTable("SearchResultRecord", table => table
                    .ContentPartRecord()                    
                    .Column<string>("webserviceURL", column => column.WithLength(200))                    
                    );
                */
                return 12;
            }

            public int UpdateFrom12()
            {

                ContentDefinitionManager.AlterPartDefinition("VendorAddPart", part => part
                    .Attachable());
                /*
                SchemaBuilder.CreateTable("SearchResultRecord", table => table
                    .ContentPartRecord()                    
                    .Column<string>("webserviceURL", column => column.WithLength(200))                    
                    );
                */
                return 13;
            }
            public int UpdateFrom13()
            {

                ContentDefinitionManager.AlterPartDefinition("VendorAdPart", part => part
                    .Attachable());
                /*
                SchemaBuilder.CreateTable("SearchResultRecord", table => table
                    .ContentPartRecord()                    
                    .Column<string>("webserviceURL", column => column.WithLength(200))                    
                    );
                */
                return 14;
            }
    }
}

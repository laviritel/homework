using System.Collections.Generic;

namespace Legacy.Web.Templates.Pages
{
    #region ContactPerson class
    public class ContactPerson 
    {
        public ContactPerson(string municipality, string county, string email)
        {
            Municipality = municipality;
            County = county;
            Email = email;
        }

        public string Municipality { get; set; }
        public string County { get; set; }
        public string Email { get; set; }

        #region ContactPerson list initialization
        public static List<ContactPerson> PopulateContactPersonList(List<ContactPerson> contactPersonList)
        {
            contactPersonList = new List<ContactPerson>();
            contactPersonList.Add(new ContactPerson("Sørfold", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Gildeskål", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Rødøy", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Dønna", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Herøy", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Alstahaug", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Brønnøy", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Sømna", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Leka", "Nord Trøndelag", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Nærøy", "Nord Trøndelag", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Meløy", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Høylandet", "Nord Trøndelag", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Bodø", "Nordland", "Kjell.Stokbakken@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Fosnes", "Nord Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Flatanger", "Nord Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Osen", "Sør Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Frøya", "Sør Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Hitra", "Sør Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Smøla", "Møre og Romsdal", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Averøy", "Møre og Romsdal", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Roan", "Sør Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Snillfjord", "Sør Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Aure", "Møre og Romsdal", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Bjugn", "Sør Trøndelag", "knut.utheim@Legacy.com"));
            contactPersonList.Add(new ContactPerson("mrHeroy", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Volda", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Vanylven", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Selje", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Vågsøy", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Bremanger", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Ørsta", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Ulstein", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Flora", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Leikanger", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Høyanger", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Fjaler", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Solund", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Hyllestad", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Gulen", "Sogn og Fjordane", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Ålesund", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Aukra", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Fræna", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Haram", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Giske", "Møre og Romsdal", "Per-Roar.Gjerde@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Askøy", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Fjell", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Sund", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Etne", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Jondal", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Kvinnherad", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Tysvær", "Rogaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Vindafjord", "Rogaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Finnøy", "Rogaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Hjelmeland", "Rogaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Flekkefjord", "Vest Agder", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Masfjorden", "Hordaland", "astrid.sande@Legacy.com"));
            contactPersonList.Add(new ContactPerson("Øygarden", "Hordaland", "astrid.sande@Legacy.com"));

            return contactPersonList;
        }
        #endregion
    }
    #endregion


}
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationMVCSecure.Models.Base;
using WebApplicationMVCSecure.Utils.Generator;
using WebApplicationMVCSecure.Utils.Generator.Attributs;

namespace WebApplicationMVCSecure.Models
{
    public class Address : BaseModel
    {
        #region Singleton

        #endregion

        #region Constants

        #endregion

        #region Attributs

        #endregion

        #region Constructor

        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion


        private String name;

        [FakerTyper(TypeEnumCustom.LOREUMONEWORD)]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String city;

        [FakerTyper(TypeEnumCustom.ADDRESSCITY)]
        public String City
        {
            get { return city; }
            set { city = value; }
        }

        //private int? countryId;

        //public int? CountryId
        //{
        //    get { return countryId; }
        //    set { countryId = value; }
        //}

        private String way;

        [FakerTyper(TypeEnumCustom.ADDRESSWAY)]
        public String Way
        {
            get { return way; }
            set { way = value; }
        }

        private String number;

        [FakerTyper(TypeEnumCustom.ADDRESSNUMBER)]
        public String Number
        {
            get { return number; }
            set { number = value; }
        }

        private String postalCode;

        [FakerTyper(TypeEnumCustom.ADDRESSPOSTALCODE)]
        public String PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        //private Country country;

        //[ForeignKey("CountryId")]
        //public Country Country
        //{
        //    get { return country; }
        //    set { country = value; }
        //}
    }
}
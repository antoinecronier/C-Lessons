using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.EnumManager
{
    public class ActionValueAttribut : Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the objectvalue for a value in an enum.
        /// </summary>
        public Action ObjectValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init an ObjectValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public ActionValueAttribut(Action value)
        {
            this.ObjectValue = value;
        }

        #endregion
    }

    public static class EnumObject
    {

        /// <summary>
        /// Will get the object value for a given enums value, this will
        /// only work if you assign the ObjectValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetObjectValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the objectvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}

using ClassLibrary1;
using DBManager.Database;
using DBManager.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.EnumManager
{
    public class EnumTester
    {
        public EnumTester()
        {
            MyEnum item = new MyEnum();
            item = MyEnum.PROD;
            if (item == MyEnum.PROD)
                item = MyEnum.RELEASE;

            MyEnum1 item1 = MyEnum1.TEST;
            if (item1.Equals(1)) { } //Cannot be true
            if ((Int32)item1 == 1){} //Dynamic cast matching enum return type

            DataConnectionResource res = DataConnectionResource.LOCALMYSQL;
            String test = res.GetStringValue();
            test = EnumString.GetStringValue(res);
        }

        public void MyEnumFunction(MyEnum item)
        {

        }
    }

    public enum MyEnum
    {
        TEST,
        RELEASE,
        PROD,
    }

    public enum MyEnum1 : Int32
    {
        TEST = 1,
        RELEASE = 2,
        PROD = 3,
    }

    public enum MyEnum2 : Int32
    {
        [StringValue("test")]
        TEST = 1,
        [StringValue("release")]
        RELEASE = 2,
        [StringValue("prod")]
        PROD = 3,
    }
}

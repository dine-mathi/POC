using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    //
    // Summary:
    //     Enumeration of the possible object types.
    [Flags]
    public enum JsonObjectType
    {
        //
        // Summary:
        //     No object type.
        None = 0,
        //
        // Summary:
        //     An array.
        Array = 1,
        //
        // Summary:
        //     A boolean value.
        Boolean = 2,
        //
        // Summary:
        //     An integer value.
        Integer = 4,
        //
        // Summary:
        //     A null.
        Null = 8,
        //
        // Summary:
        //     An number value.
        Number = 16,
        //
        // Summary:
        //     An object.
        Object = 32,
        //
        // Summary:
        //     A string.
        String = 64,
        //
        // Summary:
        //     A file (used in Swagger specifications).
        File = 128
    }
}

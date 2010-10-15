using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CHSNS.Models
{
    public enum SexType
    {
        /*
           <ListItem>
    <Selected>true</Selected>
    <Text>男</Text>
    <Value>true</Value>
  </ListItem>
  <ListItem>
    <Selected>false</Selected>
    <Text>女</Text>
    <Value>false</Value>
  </ListItem>
         */
        [Description("男")]
        Female = 0,
        [Description("女")]
        Male = 1
    }
}

/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2008-12-25
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CHSNS.MVCHelper.Wiki
{
	/// <summary>
	/// Description of WikiEngine.
	/// </summary>
    public class WikiEngine
    {
        public static string Explain(string str)
        {
            return Formatter.Format(str);
        }
    }
}

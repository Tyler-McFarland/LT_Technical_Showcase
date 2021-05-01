using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotoAlbum.Models;

namespace PhotoAlbum.Utilities
{
    class ParseJSON
    {
        public Album[] ParseJson(string jsonString)
        {
            Album[] parsedObject = null;

			try
			{
				parsedObject = JsonConvert.DeserializeObject<Album[]>(jsonString);
			}
			catch (Exception e)
            {
                throw e;
            }

            return parsedObject;
        }
    }
}

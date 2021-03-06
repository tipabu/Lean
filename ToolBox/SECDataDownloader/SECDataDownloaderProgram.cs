﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using QuantConnect.Data.Custom.SEC;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.SECDataDownloader
{
    public static class SECDataDownloaderProgram
    {
        /// <summary>
        /// Downloads and converts the data
        /// </summary>
        /// <param name="rawDestination">Destination where raw data will be written to</param>
        /// <param name="destination">Destination where processed data will be written to</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="knownEquityFolder">Folder to search for known equities, i.e. equities we will download data for</param>
        public static void SECDataDownloader(string rawDestination, string destination, DateTime start, DateTime end, string knownEquityFolder)
        {
            var download = new SECDataDownloader();
            Log.Trace("SecDataDownloaderProgram.SecDataDownloader(): Begin downloading raw files from SEC website...");
            download.Download(rawDestination, start, end);
            
            var converter = new SECDataConverter(rawDestination, destination, knownEquityFolder);
            Log.Trace("SecDataDownloaderProgram.SecDataDownloader(): Begin parsing raw files from disk...");
            converter.Process(start, end);
        }
    }
}

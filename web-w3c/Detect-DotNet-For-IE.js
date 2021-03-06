  //only for ie browser. chrome and firefox userAgent not contiant .net info so detech failed.
        var dotNETRuntimeVersion = "3.5.0.0";
        window.onload = function() {
            if (HasRuntimeVersion(dotNETRuntimeVersion)) {
                //installed dotnet 
                result.innerText = "This machine has the correct version of the .NET Framework 3.5."
            } else {
                //not install dotnet
                result.innerText = "This machine does not have the correct version of the .NET Framework 3.5." +
                    " The required version is v" + dotNETRuntimeVersion + ".";
            }
            result.innerText += "\n\nThis machine's userAgent string is: " + navigator.userAgent + ".";
        }

        // Retrieve the version from the user agent string and compare with the specified version.
        function HasRuntimeVersion(versionToCheck) {
            var userAgentString = navigator.userAgent.match(/.NET CLR [0-9.]+/g);
            if (userAgentString != null) {
                var i;
                for (i = 0; i < userAgentString.length; ++i) {
                    if (CompareVersions(GetVersion(versionToCheck), GetVersion(userAgentString[i])) <= 0) {
                        return true;
                    }
                }
            }
            return false;
        }

        // Extract the numeric part of the version string. 
        function GetVersion(versionString) {
            if (versionString != null) {
                var numericString = versionString.match(/([0-9]+)\.([0-9]+)\.([0-9]+)/i);
                return numericString.slice(1);
            }
        }

        // Compare the 2 version strings by converting them to numeric format. 
        function CompareVersions(compareVer, sourceVer) {
            if (compareVer == null || sourceVer == null) {
                //console.log("CompareVersions  version maybe null ,compareVer:" + compareVer + " ,userVer:" + sourceVer);
                return 2;
            }
            for (i = 0; i < compareVer.length; ++i) {
                var number1 = new Number(compareVer[i]);
                var number2 = new Number(sourceVer[i]);
                if (number1 < number2)
                    return -1;
                if (number1 > number2)
                    return 1;
            }
            return 0;
        }
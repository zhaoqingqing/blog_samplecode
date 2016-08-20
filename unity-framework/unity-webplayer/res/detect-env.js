var requireDotNETVer = "3.5.0.0"; //微端需要的.net版本
var chromeSupportVer = 43; //可以安装插件的chrome最高版本


window.onload = function() {
    if (HasInstallAndCanRunWebplayer()) {
        //todo start game
        Log("todo start game");
        alert("装了插件，开始游戏吧");
    } else {
        DiffOSType();
    }
}

//———————— detect os and webbrowser start ————————
//xp=1,win7=2,other=3
function DiffOSType() {
    if (platform.os.family.indexOf("Windows XP") >= 0) {
        if (HasInstallDotNet()) {
            alert("您是XP，并且已安装.NET，请下载微端");
        } else {
            alert("您是XP，但没安装.NET，请下载插件");
        }
    } else if (platform.os.family.indexOf("Windows") >= 0) {
        if (HasSupportWebPlayer()) {
            alert("您是WIN7及以上，您的浏览器支持插件 请下载插件");
        } else {
            if (HasInstallDotNet()) {
                //
                alert("您是WIN7及以上，并且已安装.NET，请下载微端");
            } else {
                alert("您是WIN7以及上，系统自带.NET，请下载微端");
            }
            //todo 下载微端
        }
    } else {
        alert("非Windows操作系统，请您下载插件");
    }
}

function HasSupportWebPlayer() {
    if (platform.name.indexOf("IE") >= 0) {
        alert(platform.name + " ,使用的是IE");
        return true;
    } else if (platform.name.indexOf("Firefox") >= 0) {
        alert(platform.name + " ,使用的是Firefox")
        return true;
    } else if (platform.name.indexOf("Chrome") >= 0) {
        if (parseInt(platform.version) > chromeSupportVer) {
            alert(platform.name + "-" + platform.version + " 此版本不支持");
            return false;
        }
        alert(platform.name + " ,您的chrome支持插件,version=" + platform.version)
        return true;
    } else {
        alert(platform.name + " ,不支持啦");
        return false;
    }
}

// browser installed and you can run webplayer
function HasInstallAndCanRunWebplayer() {
    if (HasInstallWebPlayer()) {
        if (HasSupportWebPlayer()) {
            alert("当前浏览器可以运行webplayer");
            return true;
        }
        alert("当前浏览器安装了webplayer，但并不支持无法运行");
        return false;
    }

    alert("当前浏览器没有安装webplayer，无法运行");
    return false;
}


//just install in os , not detect support
function HasInstallWebPlayer() {
    //http://docs.unity3d.ru/Manual/Detecting%20the%20Unity%20Web%20Player%20using%20browser%20scripting.html
    /**
     * NOTE 此方法只能检测是否系统安装了插件，但不保证能否运行。在360兼容模式下报错
     * SCRIPT5007: 无法获取未定义或 null 引用的属性“detachEvent” 
     * SCRIPT5007: 属性“detectUnityWebPlayerActiveX”的值为 null、未定义或不是 Function 对象 
     *  */
    // var tInstalled = false;
    // if (navigator.appVersion.indexOf("MSIE") != -1 &&
    //     navigator.appVersion.toLowerCase().indexOf("win") != -1) {
    //     tInstalled = detectUnityWebPlayerActiveX();
    // } else if (navigator.mimeTypes && navigator.mimeTypes["application/vnd.unity"]) {
    //     if (navigator.mimeTypes["application/vnd.unity"].enabledPlugin &&
    //         navigator.plugins && navigator.plugins["Unity Player"]) {
    //         tInstalled = true;
    //     }
    // }
    // return tInstalled;

    if (typeof unityObject != "undefined") {
        return true;
    }
    return false;
}

function HasInstallDotNet() {
    var isInstall = HasRuntimeVersion(requireDotNETVer);
    if (isInstall) {
        //installed dotnet 
        dotInfo.innerText = "This machine has the correct version of the .NET Framework 3.5."
    } else {
        //not install dotnet
        dotInfo.innerText = "This machine does not have the correct version of the .NET Framework 3.5." +
            " The required version is v" + requireDotNETVer + ".";
    }
    dotInfo.innerText += "\n\nThis machine's userAgent string is: " + navigator.userAgent + ".";
    return isInstall;
}

function Log(message) {
    var info = $('#result');
    info.append(message);
}



function DetectOtherBrowserSupport() {
    //other browser is support
}


//———————— detect os and webbrowser end ————————

//———————— detect dotnet start ————————
//only for ie browser. chrome and firefox userAgent not contiant .net info so detech failed.
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
//———————— detect dotnet end ————————
using UnityEngine;
using UnityEditor ;
using UnityEditor.Callbacks;

using System.IO;
using System.Collections;



public class MyAssetModificationProcessor : UnityEditor.AssetModificationProcessor
{
    
	[MenuItem("Reporter/Create")]
	public static void CreateReporter()
	{
		GameObject reporterObj = new GameObject();
		reporterObj.name = "Reporter";
		Reporter reporter = reporterObj.AddComponent<Reporter>();
		reporterObj.AddComponent<ReporterMessageReceiver>();
		//reporterObj.AddComponent<TestReporter>();

		reporter.images = new Images();
	    string imageRootPath = "Assets/Reporter/Images/";
		reporter.images.clearImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"clear.png", typeof(Texture2D));
		reporter.images.collapseImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"collapse.png", typeof(Texture2D));
		reporter.images.clearOnNewSceneImage= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"clearOnSceneLoaded.png", typeof(Texture2D));
		reporter.images.showTimeImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"timer_1.png", typeof(Texture2D));
		reporter.images.showSceneImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"UnityIcon.png", typeof(Texture2D));
		reporter.images.userImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"user.png", typeof(Texture2D));
		reporter.images.showMemoryImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"memory.png", typeof(Texture2D));
		reporter.images.softwareImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"software.png", typeof(Texture2D));
		reporter.images.dateImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"date.png", typeof(Texture2D));
		reporter.images.showFpsImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"fps.png", typeof(Texture2D));
		reporter.images.showGraphImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +".png", typeof(Texture2D));
		reporter.images.graphImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"chart.png", typeof(Texture2D));
		reporter.images.infoImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"info.png", typeof(Texture2D));
		reporter.images.searchImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"search.png", typeof(Texture2D));
		reporter.images.closeImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"close.png", typeof(Texture2D));
		reporter.images.buildFromImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"buildFrom.png", typeof(Texture2D));
		reporter.images.systemInfoImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"ComputerIcon.png", typeof(Texture2D));
		reporter.images.graphicsInfoImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"graphicCard.png", typeof(Texture2D));
		reporter.images.backImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"back.png", typeof(Texture2D));
		reporter.images.cameraImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +".png", typeof(Texture2D));
		reporter.images.logImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"log_icon.png", typeof(Texture2D));
		reporter.images.warningImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"warning_icon.png", typeof(Texture2D));
		reporter.images.errorImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"error_icon.png", typeof(Texture2D));
		reporter.images.barImage 			= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"bar.png", typeof(Texture2D));
		reporter.images.button_activeImage 	= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"button_active.png", typeof(Texture2D));
		reporter.images.even_logImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"even_log.png", typeof(Texture2D));
		reporter.images.odd_logImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"odd_log.png", typeof(Texture2D));
		reporter.images.selectedImage 		= (Texture2D)AssetDatabase.LoadAssetAtPath(imageRootPath +"selected.png", typeof(Texture2D));

		reporter.images.reporterScrollerSkin = (GUISkin)AssetDatabase.LoadAssetAtPath(imageRootPath+"reporterScrollerSkin.guiskin", typeof(GUISkin));

	}
	[InitializeOnLoad]
	public class BuildInfo
	{
		static BuildInfo ()
	    {
	        EditorApplication.update += Update;
	    }
	 
		static bool isCompiling = true ; 
	    static void Update ()
	    {
			if( !EditorApplication.isCompiling && isCompiling )
			{
	        	//Debug.Log("Finish Compile");
				if( !Directory.Exists( Application.dataPath + "/StreamingAssets"))
				{
					Directory.CreateDirectory( Application.dataPath + "/StreamingAssets");
				}
				string info_path = Application.dataPath + "/StreamingAssets/build_info.txt" ;
				StreamWriter build_info = new StreamWriter( info_path );
				build_info.Write(  "Build from " + SystemInfo.deviceName + " at " + System.DateTime.Now.ToString() );
				build_info.Close();
			}
			
			isCompiling = EditorApplication.isCompiling ;
	    }
	}
}

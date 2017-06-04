node{
  stage('get clone')
  {
  git url: 'https://github.com/jglick/simple-maven-project-with-tests.git'
  //check CODE
  }
  stage('mvn build')
  {
  //mvn构建
  timeout(time: 30, unit: 'SECONDS')
   {
     //设置30秒超时时间  
  bat 'mvn install -Dmaven.test.skip=true'
   }
  }
  stage('deploy')
   {
  bat 'deploy.bat'
     //执行部署脚本
   }
}
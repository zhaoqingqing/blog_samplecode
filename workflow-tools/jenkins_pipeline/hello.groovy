node {
	stage('svn update'){
		echo 'svn update'
	}
	stage('build excel'){
		echo 'build excel'
	}
	stage('build ab'){
		echo 'build ab'
	}
	stage('build app'){
		echo 'build app'
	}
	stage('finish'){
		echo 'finish'
	}
}
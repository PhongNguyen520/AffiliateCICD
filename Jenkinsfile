pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Verifying Docker installation'
                sh 'sudo docker --version' 
                git 'https://github.com/PhongNguyen520/AffiliateCICD.git'
            }
        }

        stage('PushDocker') {
            steps {
                withDockerRegistry(credentialsId: 'docker-hub', url: 'https://index.docker.io/v1/') {
                    sh 'docker build -t nguyenphong203/testjenkins .'
                    sh 'docker push nguyenphong203/testjenkins'
                }
            }
        }
    }
    post {
        success {
            echo 'Pipeline completed successfully!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}



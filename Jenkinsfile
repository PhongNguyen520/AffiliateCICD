pipeline{
    agent any

    stages{
        stage('Build') {
            steps {
            echo 'Verifying Docker installation'
                sh 'docker --version' 
                git 'https://github.com/PhongNguyen520/Jenkins.git'
            }
        }

        stage('PushDocker') {
            steps {
                withDockerRegistry(credentialsId: 'docker-hub', url: 'https://index.docker.io/v1/') {
                    sh 'docker build -t testjenkins .'
                    sh 'docker push testjenkins:v3'
                }
            }
        }
    }
}


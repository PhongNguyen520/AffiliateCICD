// pipeline{
//     agent any

//     stages{
//         stage('Build') {
//             steps {
//             echo 'Verifying Docker installation'
//                 sh 'docker --version' 
//                 git 'https://github.com/PhongNguyen520/AffiliateCICD.git'
//             }
//         }

//         stage('PushDocker') {
//             steps {
//                 withDockerRegistry(credentialsId: 'docker-hub', url: 'https://index.docker.io/v1/') {
//                     sh 'docker build -t testjenkins .'
//                     sh 'docker push testjenkins:v3'
//                 }
//             }
//         }
//     }
//      post {
//         success {
//             echo 'Pipeline completed successfully!'
//         }
//         failure {
//             echo 'Pipeline failed!'
//         }
//     }
// }

pipeline{
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Checking out code'
                git 'https://github.com/PhongNguyen520/AffiliateCICD.git'
            }
        }

        stage('Build and Push Docker') {
            agent {
                docker {
                    image 'docker:latest'
                    args '-v /var/run/docker.sock:/var/run/docker.sock'
                }
            }
            steps {
                echo 'Building Docker image'
                sh 'docker --version'
                withDockerRegistry(credentialsId: 'docker-hub', url: 'https://index.docker.io/v1/') {
                    sh 'docker build -t yourdockerhub/testjenkins:v3 .'
                    sh 'docker push yourdockerhub/testjenkins:v3'
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
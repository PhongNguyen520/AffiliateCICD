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
                    sh 'sudo docker build -t phongnguyen203/testjenkins .'
                    sh 'sudo docker tag phongnguyen203/testjenkins phongnguyen203/testjenkins:v3'
                    sh 'sudo docker push phongnguyen203/testjenkins:v3'
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
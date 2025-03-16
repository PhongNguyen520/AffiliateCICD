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
                echo 'Checking out code'
                git 'https://github.com/PhongNguyen520/AffiliateCICD.git'
            }
        }

        stage('Build and Push Docker') {
            steps {
                sh 'docker build -t yourdockerhub/testjenkins:v3 .'
                
                withCredentials([usernamePassword(credentialsId: 'docker-hub', passwordVariable: 'DOCKER_PASSWORD', usernameVariable: 'DOCKER_USERNAME')]) {
                    sh '''
                        echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin
                        docker push $DOCKER_USERNAME/testjenkins:v3
                    '''
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
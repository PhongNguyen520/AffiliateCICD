pipeline {
    agent any
    
    environment {
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        DOCKER_IMAGE = "nguyenphong203/testjenkins"
        DOCKER_TAG = "${env.BUILD_NUMBER}"
    }
    
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code from GitHub repository'
                checkout scm
                // Alternative if webhook doesn't provide SCM info:
                // git branch: 'main', url: 'https://github.com/PhongNguyen520/AffiliateCICD.git'
            }
        }
        
        stage('Restore Dependencies') {
            steps {
                echo 'Restoring .NET dependencies'
                sh 'dotnet restore'
            }
        }
        
        stage('Build') {
            steps {
                echo 'Building ASP.NET Web API project'
                sh 'dotnet build --configuration Release --no-restore'
            }
        }
        
        stage('Test') {
            steps {
                echo 'Running tests'
                sh 'dotnet test --no-restore --verbosity normal'
            }
        }
        
        stage('Publish') {
            steps {
                echo 'Publishing .NET application'
                sh 'dotnet publish --configuration Release --no-build --output ./publish'
            }
        }
        
        stage('Build Docker Image') {
            steps {
                echo 'Building Docker image'
                sh "docker build -t ${DOCKER_IMAGE}:${DOCKER_TAG} -t ${DOCKER_IMAGE}:latest ."
            }
        }
        
        stage('Push to Docker Hub') {
            steps {
                echo 'Pushing Docker image to Docker Hub'
                withCredentials([usernamePassword(credentialsId: 'docker-hub', passwordVariable: 'DOCKER_PASSWORD', usernameVariable: 'DOCKER_USERNAME')]) {
                    sh 'echo $DOCKER_PASSWORD | docker login -u $DOCKER_USERNAME --password-stdin'
                    sh "docker push ${DOCKER_IMAGE}:${DOCKER_TAG}"
                    sh "docker push ${DOCKER_IMAGE}:latest"
                }
            }
        }
        
        stage('Clean Up') {
            steps {
                echo 'Cleaning up local Docker images'
                sh "docker rmi ${DOCKER_IMAGE}:${DOCKER_TAG}"
                sh "docker rmi ${DOCKER_IMAGE}:latest"
                cleanWs()
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
        always {
            echo 'Cleaning up resources'
        }
    }
}

console.log("Jenkinsfile for ASP.NET Web API CI/CD Pipeline");
console.log("This pipeline includes:");
console.log("1. Code checkout from GitHub");
console.log("2. Restoring .NET dependencies");
console.log("3. Building the ASP.NET application");
console.log("4. Running tests");
console.log("5. Publishing the application");
console.log("6. Building Docker image with versioned tags");
console.log("7. Pushing to Docker Hub");
console.log("8. Cleaning up resources");
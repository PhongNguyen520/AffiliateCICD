pipeline {
    agent any
    
    environment {
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        DOCKER_IMAGE = "nguyenphong203/testjenkins"
        DOCKER_TAG = "${env.BUILD_NUMBER}"
        SOLUTION_FILE = "SWD392-AffiliLinker.sln"
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
                // Specify the solution file explicitly
                sh "dotnet restore ${SOLUTION_FILE}"
            }
        }
        
        stage('Build') {
            steps {
                echo 'Building ASP.NET Web API project'
                sh "dotnet build ${SOLUTION_FILE} --configuration Release --no-restore"
            }
        }
        
        stage('Test') {
            steps {
                echo 'Running tests'
                // You can specify test projects explicitly if needed
                sh "dotnet test ${SOLUTION_FILE} --no-restore --verbosity normal"
                // If tests fail, the pipeline will stop here
            }
        }
        
        stage('Publish') {
            steps {
                echo 'Publishing .NET application'
                // Specify the API project for publishing
                sh 'dotnet publish SWD392-AffiliLinker.API/SWD392-AffiliLinker.API.csproj --configuration Release --no-build --output ./publish'
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
                sh "docker rmi ${DOCKER_IMAGE}:${DOCKER_TAG} || true"
                sh "docker rmi ${DOCKER_IMAGE}:latest || true"
                cleanWs()
            }
        }
    }
    
    post {
        success {
            echo 'Pipeline completed successfully!'
            // You can add notifications here (email, Slack, etc.)
        }
        failure {
            echo 'Pipeline failed!'
            // You can add failure notifications here
        }
        always {
            echo 'Cleaning up resources'
        }
    }
}

console.log("Fixed Jenkinsfile for ASP.NET Web API CI/CD Pipeline");
console.log("Key fixes:");
console.log("1. Added SOLUTION_FILE environment variable to specify which solution file to use");
console.log("2. Modified dotnet commands to explicitly reference the solution file");
console.log("3. Added specific path for the publish command targeting the API project");
console.log("4. Added error handling for docker rmi commands with '|| true'");
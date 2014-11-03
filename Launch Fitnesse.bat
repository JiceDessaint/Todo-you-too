@echo off
cd _FitnesseRunner
start java -jar fitnesse-standalone.jar -p 8080
timeout /T 5 
start http://localhost:8080/TodoTests

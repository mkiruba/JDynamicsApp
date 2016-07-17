var calculatorModule = angular.module('calculatorModule', []);

calculatorModule.controller('calculatorController', ['$scope', 'calculatorRepository', 'resultsRepository', 'operationsRepository',
    function ($scope, calculatorRepository, resultsRepository, operationsRepository) {
        getCalculatorResults();
        function getCalculatorResults() {

            var promise = resultsRepository.getCalculatorResults();
            promise.then(function (results) {
                $scope.calculationResults = results;

            }, function (reason) {
                alert('Failed: ' + reason);
            });
        };
        getOperations();
        function getOperations() {

            var promise = operationsRepository.getOperations();
            promise.then(function (results) {
                $scope.operations = results;

            }, function (reason) {
                alert('Failed: ' + reason);
            });
        };

        $scope.calculate = function () {
            $scope.submitted = true;
            var promise = calculatorRepository.calculate($scope.newCalculation);
            promise.then(function () {
                $scope.userForm.$setPristine();
                getCalculatorResults();
                $scope.newCalculation = null;
            }, function (reason) {
                alert('Failed: ' + reason);
            });
        }
    }]);

calculatorModule.factory('calculatorRepository', function ($http, $q) {
    return {
        calculate: function (newCalculation) {
            var deferred = $q.defer();
            $http({
                method: 'post',
                url: '/api/calculation/', data: newCalculation
            })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (response) {
                    deferred.reject(response.statusText);
                });

            return deferred.promise;
        }
    }
});

calculatorModule.factory('resultsRepository', function ($http, $q) {
    return {
        getCalculatorResults: function (results) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/calculation', data: results
            })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (response) {
                    deferred.reject(response.statusText);
                });

            return deferred.promise;
        }
    };   
});

calculatorModule.factory('operationsRepository', function ($http, $q) {
    return {
        getOperations: function (results) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/operation', data: results
            })
                .then(function (response) {
                    deferred.resolve(response.data);
                }, function (response) {
                    deferred.reject(response.statusText);
                });

            return deferred.promise;
        }
    };
});
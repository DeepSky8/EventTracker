site.controller('DemoCtrl', function ($scope) {
			    $scope.time1 = new Date();

			    $scope.time2 = new Date();
			    $scope.time2.setHours(7, 30);
			    $scope.showMeridian = true;

			    $scope.disabled = false;
			});
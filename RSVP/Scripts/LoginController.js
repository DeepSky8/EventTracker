site.controller('LoginController', ['$scope', '$route', '$location', 'UsersApi', function ($scope, $route, $location, usersApi) {

    $scope.checkCredentials = function () {
        usersApi.save({
            EmailAddress: $scope.emailAddress,
            Password: $scope.password,
        }, function (result) {

        });
    }


    //$scope.checkCredentials = function () {
    //    eventsApi.save({
    //        eventId: $scope.currentEvent.eventId,
    //        title: $scope.currentEvent.title,
    //        location: $scope.currentEvent.location,
    //        startDay: new Date($scope.currentEvent.day),
    //        duration: $scope.currentEvent.duration,
    //        notes: $scope.currentEvent.notes,
    //        userId: $scope.currentEvent.userId,
    //    }, function (result) { $location.path('event_details') });
    //}


}]);
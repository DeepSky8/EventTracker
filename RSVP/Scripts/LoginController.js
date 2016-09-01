site.controller('LoginController', ['$scope', '$route', '$location', 'UsersApi', function ($scope, $route, $location, usersApi) {

    $scope.checkCredentials = function () {
        usersApi.UserLogin({
            UserName: userName,
            Password: password,
        }, function (result) {
            $scope.authenticated = result;
            if (result) {
                $location.path('home')
            }
            else {
                $location.path('login')
            }
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
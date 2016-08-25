﻿site.controller('EventsController', ['$scope', 'EventsApi', 'CommentsApi', '$route', '$location', function ($scope, eventsApi, commentsApi, $route, $location) {
    $scope.events = [];
    $scope.event = {};

    $scope.loadEvent = function () {
        eventsApi.get({ eventId: $route.current.params.eventId }, function (result) {
            $scope.currentEvent = result;
        });
    }

    $scope.loadEvents = function () {
        eventsApi.query({}, function (result) {
            $scope.events = result;
        });
    }

    $scope.createEvent = function () {
        eventsApi.save({
            eventId: $scope.eventId,
            title: $scope.newTitle,
            location: $scope.newLocation,
            startDay: new Date($scope.newStartDay),
            duration: $scope.newDuration,
            notes: $scope.newNotes,
        }, function (result) { $location.path('home') });
    }

    $scope.modifyEvent = function () {
        eventsApi.save({
            eventId: $scope.currentEvent.eventId,
            title: $scope.currentEvent.title,
            location: $scope.currentEvent.location,
            startDay: new Date($scope.currentEvent.day),
            duration: $scope.currentEvent.duration,
            notes: $scope.currentEvent.notes
        }, function (result) { $location.path('event_details') });
    }

    $scope.deleteConfirm = function () {
        eventsApi.get({ eventId: $route.current.params.eventId }, function (result) {
            $scope.currentEvent = result;
        });
    }

    $scope.deleteEvent = function () {
        eventsApi.delete({
            eventId: $route.current.params.eventId
        }, function (result) { $location.path('home') });
    }

    $scope.addComment = function () {
        commentsApi.save({
            EventId: $scope.currentEvent.eventId,
            commentName: $scope.commentName,
            commentText: $scope.commentText,
        }, function (result) { $location.path('event_details') });
    }

    $scope.deleteComment = function (deleteCommentId) {
        commentsApi.delete({
            commentId: deleteCommentId
        }, function (result) { $location.path('event_details') });
    }

}]);


site.run(function (editableOptions) {
    editableOptions.theme = 'bs3'; // bootstrap3 theme. Can be also 'bs2', 'default'
});
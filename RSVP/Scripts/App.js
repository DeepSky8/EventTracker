var site = angular.module('RSVP', ['ngResource', 'ngRoute', 'ui.bootstrap', 'ui.bootstrap.tpls', 'ui.bootstrap.collapse', 'xeditable' ]);

site.factory('EventsApi', ['$resource', function ($resource) { return $resource('/api/Events/', {}, {}); }]);
site.factory('CommentsApi', ['$resource', function ($resource) { return $resource('/api/Comments/', {}, {}); }]);

site.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/CreateNewEvent', {
            templateUrl: 'events/create_event.html',
            controller: 'EventsController'
        }).
        when('/ShowEvents', {
            templateUrl: 'events/show_events.html',
            controller: 'EventsController'
        }).
          when('/Home', {
              templateUrl: 'events/home.html',
              controller: 'EventsController'
          }).
          when('/EditEvent/:eventId', {
              templateUrl: 'events/edit_event.html',
              controller: 'EventsController'
          }).
          when('/CommentEvent/:eventId', {
              templateUrl: 'events/comment_event.html',
              controller: 'EventsController'
          }).
          when('/ShowEventsButtons', {
              templateUrl: 'events/all_events_buttons.html',
              controller: 'EventsController'
          }).
          when('/DeleteEvent/:eventId', {
              templateUrl: 'events/delete_event.html',
              controller: 'EventsController'
          }).
          when('/EventDetails/:eventId', {
              templateUrl: 'events/event_details.html',
              controller: 'EventsController'
          }).
        otherwise({
            redirectTo: '/Home'
        });
  }]);


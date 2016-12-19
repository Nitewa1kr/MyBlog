var myBlogApp = angular.module('myBlogApp', []);
myBlogApp.controller('BlogController', function ($scope,$http)
{
    $http.get('home/GetPosts').success(function () {
        $scope.posts = result;
    })
    .error(function (data) {
        console.log(data);
    });
    //add posts
    $scope.newPost = "";
    $scope.addPost = function ()
    {
        $http.post("/home/addPost/", { newPost: $scope.newPost })
        .success(function (result) {
            $scope.post = result;
            $scope.newPost = "";

        })
        .error(function (data) {
            console.log(data);
        });
    }
});
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
        $http.post("/home/addPost/",
            {
                newTitle: $scope.newTitle,
                newPost: $scope.newPost,
                newAuthor: $scope.newAuthor,
                newDate: $scope.newDate
            })
        .success(function (result) {
            $scope.posts = result;
            $scope.newPost = "";

        })
        .error(function (data) {
            console.log(data);
        });
    }
});
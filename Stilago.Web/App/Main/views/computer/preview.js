(function() {
    var controllerId = 'app.views.computerPreview';
    angular.module('app').controller(controllerId, [
         '$scope', '$stateParams', '$state', 'abp.services.app.computer', function ($scope, $stateParams, $state, computerService) {
            var vm = this;
            

            $scope.form = {};

            computerService
                .get({ id: ($stateParams.id == undefined ? null : $stateParams.id) })
                .success(function (data) {
                    $scope.form = data.computer;
                });


            $scope.addToShoppingCart = function () {
                toastr.info("This is not yet implemented");
            }

        }
    ]);
})();
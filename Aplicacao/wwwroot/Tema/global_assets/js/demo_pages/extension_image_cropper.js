/* ------------------------------------------------------------------------------
 *
 *  # Image Cropper
 *
 *  Demo JS code for extension_image_cropper.html page
 *
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var ImageCropper = function() {


    //
    // Setup module components
    //

    // Image cropper
    var _componentImageCropper = function() {
        if (!$().cropper) {
            console.warn('Warning - cropper.min.js is not loaded.');
            return;
        }

        // Default initialization
        $('.crop-basic').cropper();

        // Hidden overlay
        $('.crop-modal').cropper({
            modal: false
        });

        // Fixed position
        $('.crop-not-movable').cropper({
            cropBoxMovable: false,
            data: {
                x: 75,
                y: 50,
                width: 350,
                height: 250
            }
        });

        // Fixed size
        $('.crop-not-resizable').cropper({
            cropBoxResizable: false,
            data: {
                x: 10,
                y: 10,
                width: 300,
                height: 300
            }
        });

        // Disabled autocrop
        $('.crop-auto').cropper({
            autoCrop: false 
        });

        // Disabled drag
        $('.crop-drag').cropper({
            movable: false 
        });

        // 16:9 ratio
        $('.crop-16-9').cropper({
            aspectRatio: 16/9
        });

        // 4:3 ratio
        $('.crop-4-3').cropper({
            aspectRatio: 4/3
        });

        // Minimum zone size
        $('.crop-min').cropper({
            minCropBoxWidth: 150,
            minCropBoxHeight: 150
        });

        // Disabled zoom
        $('.crop-zoomable').cropper({
            zoomable: false
        });


        // Demo cropper
        // ------------------------------

        // Define variables
        var $cropper = $('.cropper'),
            $image = $('#demo-cropper-image'),
            $download = $('#download'),
            $dataX = $('#dataX'),
            $dataY = $('#dataY'),
            $dataHeight = $('#dataHeight'),
            $dataWidth = $('#dataWidth'),
            $dataScaleX = $('#dataScaleX'),
            $dataScaleY = $('#dataScaleY'),
            options = {
                aspectRatio: 1,
                preview: '.preview',
                crop: function (e) {
                    $dataX.val(Math.round(e.detail.x));
                    $dataY.val(Math.round(e.detail.y));
                    $dataHeight.val(Math.round(e.detail.height));
                    $dataWidth.val(Math.round(e.detail.width));
                    $dataScaleX.val(e.detail.scaleX);
                    $dataScaleY.val(e.detail.scaleY);
                }
            };

        // Initialize cropper with options
        $cropper.cropper(options);


        //
        // Toolbar
        //

        $('.demo-cropper-toolbar').on('click', '[data-method]', function () {
            var $this = $(this),
                data = $this.data(),
                $target,
                result;

            if ($image.data('cropper') && data.method) {
                data = $.extend({}, data);

                if (typeof data.target !== 'undefined') {
                    $target = $(data.target);

                    if (typeof data.option === 'undefined') {
                        data.option = JSON.parse($target.val());
                    }
                }

                result = $image.cropper(data.method, data.option, data.secondOption);

                switch (data.method) {
                    case 'scaleX':
                    case 'scaleY':
                        $(this).data('option', -data.option);
                    break;

                    case 'getCroppedCanvas':
                        if (result) {

                            // Init modal
                            $('#getCroppedCanvasModal').modal().find('.modal-body').html(result);

                            // Download image
                            $download.attr('href', result.toDataURL('image/jpeg'));
                        }
                    break;
                }
            }
        });


        //
        // Aspect ratio
        //

        $('.demo-cropper-ratio').on('change', 'input[type=radio]', function () {
            options[$(this).attr('name')] = $(this).val();
            $image.cropper('destroy').cropper(options);
        });


        //
        // Switching modes
        //

        // Crop and clear
        var cropClear = document.querySelector('.clear-crop-switch');
        cropClear.addEventListener('change', function() {
            if(cropClear.checked) {

                // Crop mode
                $cropper.cropper('crop');

                // Enable other options
                enableDisable.disabled = false;
                destroyCreate.disabled = false;
            }
            else {

                // Clear move
                $cropper.cropper('clear');

                // Disable other options
                enableDisable.disabled = true;
                destroyCreate.disabled = true;
            }
        });

        // Enable and disable
        var enableDisable = document.querySelector('.enable-disable-switch');
        enableDisable.addEventListener('change', function() {
            if(enableDisable.checked) {

                // Enable cropper
                $cropper.cropper('enable');

                // Enable other options
                cropClear.disabled = false;
                destroyCreate.disabled = false;
            }
            else {

                // Disable cropper
                $cropper.cropper('disable');

                // Disable other options
                cropClear.disabled = true;
                destroyCreate.disabled = true;
            }
        });

        // Destroy and create
        var destroyCreate = document.querySelector('.destroy-create-switch');
        destroyCreate.addEventListener('change', function() {
            if(destroyCreate.checked) {

                // Initialize again
                $cropper.cropper({
                    aspectRatio: 1,
                    preview: '.preview',
                    data: {
                        x: 208,
                        y: 22
                    }
                });

                // Enable other options
                cropClear.disabled = false;
                enableDisable.disabled = false;
            }
            else {

                // Destroy cropper
                $cropper.cropper('destroy');
                
                // Disable other options
                cropClear.disabled = true;
                enableDisable.disabled = true;
            }
        });


        //
        // Methods
        //

        // Get data
        $('#getData').on('click', function() {
            $('#showData1').val(JSON.stringify($cropper.cropper('getData')));
        });

        // Set data
        $('#setData').on('click', function() {
            $cropper.cropper('setData', {
                x: 291,
                y: 86,
                width: 158,
                height: 158
            });

            $('#showData1').val('Image data has been changed');
        });


        // Get container data
        $('#getContainerData').on('click', function() {
            $('#showData2').val(JSON.stringify($cropper.cropper('getContainerData')));
        });

        // Get image data
        $('#getImageData').on('click', function() {
            $('#showData2').val(JSON.stringify($cropper.cropper('getImageData')));
        });


        // Get canvas data
        $('#getCanvasData').on('click', function() {
            $('#showData3').val(JSON.stringify($cropper.cropper('getCanvasData')));
        });

        // Set canvas data
        $('#setCanvasData').on('click', function() {
            $cropper.cropper('setCanvasData', {
                left: -50,
                top: 0,
                width: 750,
                height: 750
            });

            $('#showData3').val('Canvas data has been changed');
        });


        // Get crop box data
        $('#getCropBoxData').on('click', function() {
            $('#showData4').val(JSON.stringify($cropper.cropper('getCropBoxData')));
        });

        // Set crop box data
        $('#setCropBoxData').on('click', function() {
            $cropper.cropper('setCropBoxData', {
                left: 395,
                top: 68,
                width: 183,
                height: 183
            });

            $('#showData4').val('Crop box data has been changed');
        });
    };


    //
    // Return objects assigned to module
    //

    return {
        init: function() {
            _componentImageCropper();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function() {
    ImageCropper.init();
});

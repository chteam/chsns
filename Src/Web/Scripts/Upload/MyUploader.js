
function CreateUploader(handler,session,text) {
   var swfu = new SWFUpload({
        upload_url: handler,//"upload.aspx",
        post_params: {
            "ASPSESSID": session//"<%=Session.SessionID %>"
        },file_size_limit: "2 MB",
        file_types: "*.jpg;*.png;*.gif;*.jpeg",
        file_types_description: "JPG Images",
        file_upload_limit: "0",

        file_queue_error_handler: fileQueueError,
        file_dialog_complete_handler: fileDialogComplete,
        upload_progress_handler: uploadProgress,
        upload_error_handler: uploadError,
        upload_success_handler: uploadSuccess,
        upload_complete_handler: uploadComplete,

        button_image_url: "/images/XPButtonNoText_160x22.png",
        button_placeholder_id: "spanButtonPlaceholder",
        button_width: 160,
        button_height: 22,
        button_text: '<span class="button">'+text+'</span>',
        button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
        button_text_top_padding: 1,
        button_text_left_padding: 5,
        flash_url: "/Scripts/Upload/swfupload.swf", // Relative to this file
        custom_settings: {
            upload_target: "divFileProgressContainer"
        },
        debug: false
    });
}
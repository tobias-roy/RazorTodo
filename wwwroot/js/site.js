// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
  var placeholderElement = $('#modal-placeholder');

  $('button[data-toggle="ajax-modal"]').click(function (event) {
      var url = $(this).data('url');
      $.get(url).done(function (data) {
          placeholderElement.html(data);
          placeholderElement.find('.modal').modal('show');
      });
  });

  $('#btnLogout').click(function () {
    $.ajax({
      url: '@Url.Action("Logout", "Index")',
      type: 'POST',
      succes: function (data) {
        location.reload()
      }
    })
  })
 
  $('button[data-toggle="ajax-edit-modal"]').click(function (event) {
    var url = $(this).data('url');
    var data = {id: this.id};  
    $.get(url, data).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    });
  });

  placeholderElement.on('click', '[data-save="modal"]', function (event) {
    event.preventDefault();

    var form = $(this).parents('.modal').find('form');
    var actionUrl = form.attr('action');
    var dataToSend = form.serialize();

    $.post(actionUrl, dataToSend).done(function (data) {
      var newBody = $('.modal-body', data);
      placeholderElement.find('.modal-body').replaceWith(newBody);

      var isValid = newBody.find('[name="IsValid"]').val() == 'True';
      if (isValid) {
          placeholderElement.find('.modal').modal('hide');
          location.reload();
      }
    }).fail(function(){
      $("#validationErrorMessage").show();
      $("#registrationErrorMessage").show();
    });
  });

  placeholderElement.on('click', '[data-edit="modal"]', function (event) {
    event.preventDefault();
    
    var form = $(this).parents('.modal').find('form');
    var actionUrl = form.attr('action');
    var dataToSend = form.serialize();

    $.post(actionUrl, dataToSend).done(function (data) {
      var newBody = $('.modal-body', data);
      placeholderElement.find('.modal-body').replaceWith(newBody);

      var isValid = newBody.find('[name="IsValid"]').val() == 'True';
      if (isValid) {
          placeholderElement.find('.modal').modal('hide');
          location.reload();
      }
    });
  });

  placeholderElement.on('click', '[data-dismiss="modal"]', function (event) {
    event.preventDefault();
    placeholderElement.find('.modal').modal('hide');
    location.reload();
  });
});

function checkMatch() {
  var input = document.getElementById('txtConfirmPassword');
  if (input.value != document.getElementById('txtPassword').value) {
      input.setCustomValidity('Password Must be Matching.');
      $('#btnRegister').hide();
      document.getElementById('registrationErrorMessage').innerHTML = "Password does not match";
      $("#registrationErrorMessage").show();
  } else {
      input.setCustomValidity('');
      $('#btnRegister').show();
      $('#registrationErrorMessage').hide();
      document.getElementById('registrationErrorMessage').innerHTML = "Registration failed";
  }
}
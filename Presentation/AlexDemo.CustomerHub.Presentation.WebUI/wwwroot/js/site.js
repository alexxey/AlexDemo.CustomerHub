// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function deleteEntity(entityId, deleteUrl, entityName) {

	let entityType = entityName;

	if (confirm(`Are you sure you want to delete this ${entityType}?`)) {

		const token = $('input[name="__RequestVerificationToken"]').val();
		if (token == null)
		{
			alert('Unable to complete operation due to security reasons');
		}
		else {
			$.ajax({
				url: deleteUrl + '/' + entityId,
				type: 'POST',
				headers: {
					'RequestVerificationToken': token
				},
				success: function () {
					location.reload();
					alert(`${entityType} deleted successfully.`);
				},
				error: function () {
					alert(`Failed to delete the ${entityType}.`);
				}
			});
		}		
	}
}


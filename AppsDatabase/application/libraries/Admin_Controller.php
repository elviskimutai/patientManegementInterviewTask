<?php
class Admin_Controller extends MY_Controller
{

	function __construct ()
	{
		parent::__construct();

		
		// Login check
		$exception_uris = array(
			'admin/user/login', 
			'admin/user/logout'
		);
		
		if (in_array(uri_string(), $exception_uris) == FALSE) {
			if ($this->admin_model->loggedin() == FALSE) {
				redirect('admin/user/login');
			}
		}
	
	}
}
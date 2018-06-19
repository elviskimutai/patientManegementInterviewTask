<?php
class Notification extends CI_Controller
{

	public function __construct (){
		parent::__construct();
		$this->load->model('notification_model');
	}
	public function getUserNotifications(){
		$user_id = $this->input->post('user_id');

		$data = $this->notification_model->getNotifications($user_id);
		$feeds = array();

		if (count($data)) {
				$feeds['message'] = 'Success';
				$feeds['success'] = true;
				$feeds['notifications'] = $data;
		}else{
				$feeds['message'] = 'No notifications found!';
				$feeds['success'] = false;
				$feeds['notifications'] = null;
		}
		echo json_encode($feeds);
	}

}

	
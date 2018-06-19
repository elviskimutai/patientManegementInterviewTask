<?php
class Profilepic extends CI_Controller
{

	public function __construct ()
	{
		parent::__construct();
		$this->load->model('profilepic_model');
	}

	public function upload(){
		$post = array(
			"image" => $this->input->post('image'),
			"name" => $this->input->post('name'),
			"user_id" => $this->input->post('user_id'),
		);


		$data = $this->profilepic_model->insert($post);
		$feed = array();

		if( $data != 0) {
				$feed['message'] = 'Success';
				$feed['success'] = true;
				//$feed['post'] = $this->feed_model->get($data);
			
		}else{
			$feed['success'] = false;
			$feed['message'] = 'Something went wrong';
			//$feed['feed'] = array();
		}

		echo json_encode($feed);
	}

}

	
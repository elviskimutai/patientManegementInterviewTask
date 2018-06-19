<?php
class Comment extends CI_Controller
{

	public function __construct ()
	{
		parent::__construct();
		$this->load->model('comment_model');
	}

	public function commentPhoto(){

		$comment = array(
		"user_id" => $this->input->post('user_id'),
		"feed_id" => $this->input->post('feed_id'),
		"comment" => $this->input->post('comment')
		);

		$data = $this->comment_model->insert($comment);

		$comments = array();

		if( $data != 0) {
				$comments['message'] = 'Success';
				$comments['success'] = true;
				$comments['comment'] = $this->comment_model->get($data);
		}else{
			$comments['success'] = false;
			$comments['message'] = 'Something went wrong';
			$comments['comment'] = array();
		}

		echo json_encode($comments);
	}

	public function photoComments(){

		$feed_id = $this->input->post('feed_id');
		$data = $this->comment_model->with('user')->getPhotoComements($feed_id);
		$comments = array();

		if( $data != 0) {
				$comments['message'] = 'Success';
				$comments['success'] = true;
				$comments['comments'] = $data;
		}else{
			$comments['success'] = false;
			$comments['message'] = 'Something went wrong';
			$comments['comments'] = null;
		}

		echo json_encode($comments);
	}
	
}

	
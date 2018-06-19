<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

/**
 * @author :John Kiragu
 * project :Cultural mapping
 */
class Database extends CI_Model {

    public function __construct() {
        parent::__construct();
    }

    function get_all($table) {
        $this->db->order_by('id', 'desc');
        $qry = $this->db->get($table);
        return $qry;
    }

    //GET ALL WHERE
    function get_all_where($table, $whr) {
        if ($table != "") {

            $query = $this->db->get_where($table, $whr);
            if ($query->num_rows() > 0) {
                return $query;
            } else {
                return false;
            }
        }
    }

    //GET ALL LIKE
    function get_all_like($table, $whr) {
        if ($table != "") {

            $this->db->like($whr);
            $query = $this->db->get($table);
            if ($query->num_rows() > 0) {
                return $query;
            } else {
                return false;
            }
        }
    }

    //GET ROW WHERE
    function get_row_where($whr, $table = "") {
        if ($table != "") {

            $query = $this->db->get_where($table, $whr);
            if ($query->num_rows() > 0) {
                return $query->row();
            } else {
                return false;
            }
        }
    }

    function insertdata($table,$data){
        
         if($table!=""){
             
             $query=$this->db->insert($table,$data);
         }
        
         return $query;
    }
    
    /**
     * 
     * @param type $where
     * @param type $table
     * @param type $data
     * @return type  query with the inserted data baasically a boolean value
     */
    
    function update($where,$table,$data){
        
        if($where==""){
            
            $query=$this->db->update($table,$data);
            
        }else{
            
            $this->db->where($where);
            $query=$this->db->update($table,$data);
        }
         
        return $query;
    }
    
    function remove($table,$id){
        
      $query= $this->db->delete($table, array('id' => $id)); 
      
      return $query;
    }

}

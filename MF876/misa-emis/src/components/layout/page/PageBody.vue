<template>
  <div class="page-body d-flex">
      <div class="page-body-sidebar">
          <div class="b-sidebar-select d-flex">
              <div class="b-select-drop-icon"></div>
              <div class="b-select-title">Trường THCS MISA</div>                
          </div>
          <div class="b-select-list">
              <ul class="list-item" v-for="(department, i) in departments" :key="i">
                  <li class="d-flex"> <div class="b-select-item-title"> <div class="item-text">{{department.departmentName}}</div> </div> <div class="item-tool-icon"></div></li>
              </ul>
          </div>
          <div class="b-add-department d-flex">
              <div class="b-add-icon"></div>
              <div class="b-add-department-title">Thêm tổ bộ môn</div>
          </div>
      </div>
      <div class="page-body-content">
          <div class="page-body-header d-flex">
              <div class="b-header-left">
                  <div class="search-tool">
                      <input class="search-input" type="text" placeholder="Nhập Số hiệu cán bộ hoặc Tên cán bộ để tìm kiếm,...">
                      <div class="icon-search"></div>
                  </div>
              </div>
              <div class="b-header-right">
                  <button @click="addEmployee" class="add-btn">Thêm</button>
                  <div class="more-tool-btn"></div>
              </div>
          </div>
          <div class="page-body-table">
              <page-table
              @getDepartment="getDepartment"
              ></page-table>
          </div>
          <div class="page-body-footer d-flex">
              <div class="b-footer-left flex-left">
                  <div class="select-page d-flex">
                      <div class="icon-first-page icon-paging"></div>
                      <div class="icon-prev-page icon-paging"></div>
                      <div class="page-number">
                          <input type="text" class="page-number-input " value="2">
                      </div>
                      <div class="icon-next-page icon-paging"></div>
                      <div class="icon-last-page icon-paging"></div>
                  </div>
                  <div class="page-detail flex-left">
                      <b>1/3</b> trang (<b>138</b> bản ghi)
                  </div>
              </div>
                <div class="b-footer-right flex-right">
                    <div class="back-btn">Quay lại</div>
                </div>
          </div>
      </div>
  </div>
</template>

<script>
import PageTable from './PageTable.vue'
export default {
  components: { PageTable },
    name:"PageBody",
    data(){
        return{
            departments:[],
        }
    },
    created() {
        
    },
    methods:{
        getDepartment(departments){
            this.departments = departments;
        },
        addEmployee(){
            this.$emit("openForm");
        }

    }
}
</script>

<style scoped>
@import "../../../css/layout/page/pageBody.css";
@import "../../../css/layout/page/pageBodyHeader.css";
@import "../../../css/layout/page/pageBodyTable.css";
@import "../../../css/layout/page/pageBodySidebar.css";
@import "../../../css/layout/page/pageBodyFooter.css";
</style>

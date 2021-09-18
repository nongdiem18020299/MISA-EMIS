<template>
  <div class="employee-dialog d-flex">
    <div class="employee-form">
      <div class="e-form-content d-flex">
        <div class="e-form-img-container">
          <div class="select-img">
            <div class="select-img-container">
              <div class="select-img-icon"></div>
              <input
                type="file"
                name="file"
                id="file"
                class="img-input"
                data-file="File"
                accept=".jpg, .jpeg, .png, .gif"
              />
            </div>
            <div class="img-btn"><label for="file">Chọn ảnh</label></div>
            <div class="label-info">
              <div class="label-name">Nông Thị Diễm</div>
              <div class="label-code">GV-124</div>
            </div>
          </div>
        </div>
        <div class="e-form-detail">
          <div class="form-icon-question"></div>
          <div class="form-icon-close"
          @click="closeForm"
          ></div>
          <div class="form-detail-title">Thêm hồ sơ Cán bộ, giáo viên</div>
          <div class="user-info">
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">
                  Họ và tên <span> *</span>
                </div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">
                  Số hiệu cán bộ <span> *</span>
                </div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">Số điện thoại</div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">Email</div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">Tổ bộ môn</div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">Môn dạy</div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">QL kho, phòng</div>
                <div class="form-item-input"><input type="text" /></div>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-checkbox d-flex">
                  <input type="checkbox" />
                </div>
                <div class="form-checkbox-label">Trình độ nghiệp vụ QLTB</div>
              </div>
              <div class="form-item d-flex">
                <div class="form-item-checkbox d-flex">
                  <input type="checkbox" />
                </div>
                <div class="form-checkbox-label">Đang làm việc</div>
              </div>
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">Ngày nghỉ việc</div>
                <div class="form-item-input"><input type="date" /></div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="e-form-footer">
        <div class="close-btn form-footer-btn" @click="closeForm">Đóng</div>
        <div class="save-btn form-footer-btn">Lưu</div>
      </div>
    </div>
  </div>
</template>

<script>
// import draggable from "vuedraggable";
export default {
  name: "EmployeeDialog",
  components: {},
  props:{
    Employee:[],
  }
  ,
  methods:{
    closeForm(){
      this.$emit("closeForm");
    }
  }
};
</script>

<style scoped>
@import "../../css/dialog/employeeDialog.css";
</style>
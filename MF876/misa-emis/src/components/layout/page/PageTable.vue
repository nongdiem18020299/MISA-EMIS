<template>
  <div class="base-table">
    <table>
      <thead>
        <tr>
          <th class="col-check-box"><input type="checkbox" /></th>
          <th>Số hiệu cán bộ</th>
          <th>Họ và tên</th>
          <th>Số điện thoại</th>
          <th>Tổ bộ môn</th>
          <th>Môn dạy</th>
          <th>QL kho, phòng</th>
          <th>Đào tạo QLTB</th>
          <th>Đang làm việc</th>
          <th class="tool-col"><div class="tool-col"></div></th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(employee, i) in employees"
          :key="i"
          v-bind:class="{ 'even-row': i % 2 != 0 }"
        >
          <td class="col-check-box">
            <div class="check-box-btn"><input type="checkbox" /></div>
          </td>
          <td>
            <div :title="employee.employeeCode" class="text-cell">
              {{ employee.employeeCode }}
            </div>
          </td>
          <td>
            <div :title="employee.fullName" class="text-cell col-full-name">
              {{ employee.fullName }}
            </div>
          </td>
          <td>
            <div :title="employee.phoneNumber" class="text-cell">
              {{ employee.phoneNumber }}
            </div>
          </td>
          <td>
            <div :title="employee.departmentName" class="text-cell">
              {{ employee.departmentName }}
            </div>
          </td>
          <td>
            <div :title="employee.subjectName" class="text-cell">
              {{ employee.subjectName }}
            </div>
          </td>
          <td>
            <div :title="employee.roomName" class="text-cell">
              {{ employee.roomName }}
            </div>
          </td>
          <td>
            <div class="text-cell">
              <div
                class="check-icon"
                v-bind:class="{ 'is-checked': employee.trainingStatus == 1 }"
              ></div>
            </div>
          </td>
          <td>
            <div class="text-cell">
              <div
                class="check-icon"
                v-bind:class="{ 'is-checked': employee.workStatus == 1 }"
              ></div>
            </div>
          </td>
          <td class="tool-col ">
            <div class="tool-table d-flex"><div class="edit-icon"></div>
            <div class="remove-icon"></div></div>
            
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import EmployeeApi from "../../../api/components/employee/EmployeeApi.js";
import DepartmentApi from "../../../api/components/department/DepartmentApi.js";
import RoomApi from "../../../api/components/room/RoomApi.js";
import SubjectApi from "../../../api/components/subject/SubjectApi.js";
export default {
  name: "PageTable",
  data() {
    return {
      employees: [],
      departments: [],
      rooms: [],
      subjects: [],
    };
  },
  created() {
    this.loadRoom();
    this.loadSubject();
    this.loadDepartment();
    this.loadData();
  },
  methods: {
    /**
     * Hàm load dữ liệu phòng kho
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadRoom() {
      RoomApi.getAll()
        .then((res) => {
          this.rooms = res.data;
          console.log(res.data);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm load dữ liệu môn học
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadSubject() {
      SubjectApi.getAll()
        .then((res) => {
          this.subjects = res.data;
          console.log(res.data);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm load dữ liệu phòng ban, tổ bộ môn
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadDepartment() {
      DepartmentApi.getAll()
        .then((res) => {
          this.departments = res.data;
          this.$emit("getDepartment", this.departments);
          console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm load dữ liệu nhân viên
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadData() {
      EmployeeApi.getAll()
        .then((res) => {
          // this.employees = res.data;
          this.formatData(res.data);
          console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    formatData(data) {
      for (var employee of data) {
        for (var department of this.departments) {
          if (employee["departmentId"] == department["departmentId"]) {
            employee["departmentName"] = department["departmentName"];
          }
        }
        for (var room of this.rooms) {
          if (employee["roomId"] == room["roomId"]) {
            employee["roomName"] = room["roomName"];
          }
        }
        for (var subject of this.subjects) {
          if (employee["subjectId"] == subject["subjectId"]) {
            employee["subjectName"] = subject["subjectName"];
          }
        }
      }
      this.employees = data;
    },
  },
};
</script>

<style scoped>
@import "../../../css/layout/page/pageBodyTable.css";
</style>
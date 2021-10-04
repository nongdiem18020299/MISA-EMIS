<template>
  <div class="sidebar expand" v-bind:class="{'collapse' : !isWide}">
    <div class="sidebar-header d-flex">
      <div class="sb-header-logo d-flex"  v-show="isWide">
        <div class="sb-header-icon"></div>
        <div class="sb-header-title">Thiết bị</div>
      </div>
      <div class="sb-header-menu-icon" @click="openSidebar"></div>
    </div>
    <div class="sidebar-menu">
      <div class="sb-menu-item d-flex">
        <div class="sb-menu-item-icon over-view"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Tổng quan</div>
      </div>
      <div class="sb-menu-item d-flex">
        <div class="sb-menu-item-icon device"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Thiết bị</div>
      </div>
      <div class="sb-menu-item d-flex">
        <div class="sb-menu-item-icon order"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Mượn trả</div>
      </div>
      <div class="sb-menu-item d-flex">
        <div class="sb-menu-item-icon recommend"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Đề nghị mua sắm</div>
      </div>
      <div class="sb-menu-item d-flex">
        <div class="sb-menu-item-icon search"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Tra cứu</div>
      </div>
      <div class="sb-menu-item d-flex sb-menu-selected ">
        <div class="sb-menu-item-icon system"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Hệ thống</div>
      </div>
      <div class="sb-menu-item d-flex">
        <div class="sb-menu-item-icon report"></div>
        <div class="sb-menu-item-label"  v-show="isWide">Báo cáo</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Sidebar",
  data(){
      return{
          isWide:false,
      }
  },
  methods:{
      openSidebar(){
          this.isWide = !this.isWide;
          this.$emit('sidebarCollapse', this.isWide);
      }
  }
};
</script>

<style scoped>
@import "../../css/layout/sidebar.css";
</style>
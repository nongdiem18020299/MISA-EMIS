<template>
  <div class="sidebar expand">
      <div class="sidebar-header d-flex">
          <div class="sb-header-logo d-flex">
              <div class="sb-header-icon"></div>
           <div class="sb-header-title">Thiết bị</div>
          </div>           
           <div class="sb-header-menu-icon"></div>
      </div>
      <div class="sidebar-menu">
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon over-view"></div>
              <div class="sb-menu-item-label">Tổng quan</div>
          </div>
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon device"></div>
              <div class="sb-menu-item-label">Thiết bị</div>
          </div>
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon order"></div>
              <div class="sb-menu-item-label">Mượn trả</div>
          </div>
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon recommend"></div>
              <div class="sb-menu-item-label">Đề nghị mua sắm</div>
          </div>
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon search"></div>
              <div class="sb-menu-item-label">Tra cứu</div>
          </div>
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon system"></div>
              <div class="sb-menu-item-label">Hệ thống</div>
          </div>
          <div class="sb-menu-item d-flex">
              <div class="sb-menu-item-icon report"></div>
              <div class="sb-menu-item-label">Báo cáo</div>
          </div>
      </div>
  </div>
</template>

<script>
export default {
    name:"Sidebar",
}
</script>

<style scoped>
@import "../../css/layout/sidebar.css" 
</style>
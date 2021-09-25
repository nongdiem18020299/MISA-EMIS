<template>
  <div class="form-item-input">
    <input
      :type="type"
        :value="modelValue"
        @input="updateInput"
        @focus="onFocus=true"
    />
  </div>
</template>

<script>
export default {
  name: "BaseInput",
  props: {
    modelValue: {
      type: [String, Number],
      default: "",
    },
    type: {
      type: String,
      default: "text",
    },
  },
  data() {
    return {
      onFocus: false,
    };
  },
  methods: {
    updateInput(event) {
      this.$emit("update:modelValue", event.target.value);
    },
  },
};
</script>

<style>
@import "../../css/base/baseInput.css"
</style>
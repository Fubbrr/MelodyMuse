<template>
  <div class="personal-info">
    <TheHeader :current-page="currentPage"/>
    <TheAside />
    <el-card>
      <div slot="header" class="clearfix">
        <span>个人信息</span>
      </div>
      <div class="info-container">
        <div class="left-panel">
          <el-button type="primary" @click="$router.push('/ForgottenPassword')">修改密码</el-button>
        </div>
        <div class="right-panel">
          <el-form :model="userInfo" label-width="80px">
            <el-form-item label="昵称">
              <el-input v-model="userInfo.nickname"></el-input>
            </el-form-item>
            <el-form-item label="生日">
              <el-date-picker v-model="userInfo.birthday" type="date" placeholder="选择日期"></el-date-picker>
            </el-form-item>
              <el-form-item label="年龄">
              <el-input :value="calculateAge(userInfo.birthday) + '岁'" disabled></el-input>
            </el-form-item>
            <el-form-item label="性别">
              <el-radio-group v-model="userInfo.gender">
                <el-radio label="男">男</el-radio>
                <el-radio label="女">女</el-radio>
              </el-radio-group>
            </el-form-item>
            <el-form-item label="手机号">
              <el-input v-model="userInfo.phone"></el-input>
            </el-form-item>
            <el-form-item label="邮箱">
              <el-input v-model="userInfo.email" suffix-icon="el-icon-edit" @click="showChangeEmailDialog"></el-input>
            </el-form-item>
            <el-form-item>
              <el-button type="primary" @click="saveInfo">保存</el-button>
            </el-form-item>
          </el-form>
        </div>
      </div>
    </el-card>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import TheHeader from '@/components/SimpleHeader.vue';
import TheAside from '@/components/TheAside.vue';
import api from '../api/http.js'

export default defineComponent({
  data() {
    return {
      //avatar: 'https://via.placeholder.com/100',
      userInfo: {
        userId: '001',
        nickname: '',
        password: '',
        birthday: '',
        gender: '',
        phone: '',
        email: '',
        status:'',
      },
      currentPage: '个人信息',
      //changeAvatarDialogVisible: false,
      changePasswordDialogVisible: false,
      changeEmailDialogVisible: false,
      //newAvatar: null,
      passwordForm: {
        oldPassword: '',
        newPassword: '',
        confirmPassword: '',
      },
      newEmail: '',
      resetError: '',
    };
  },
  components: {
    TheHeader,
    TheAside
  },
  methods: {
    //利用出生日期计算年龄
    calculateAge(birthday: string) {
      if (!birthday) return '';
      const birthDate = new Date(birthday);
      const today = new Date();
      let age = today.getFullYear() - birthDate.getFullYear();
      const monthDifference = today.getMonth() - birthDate.getMonth();
      if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
        age--;
      }
      return age;
    },

    async fetchUserInfo(userId: string) {
      try {
        const response = await api.apiClient.get(`/api/users/info`);
        if (response.status === 200) {
                // 打印从后端获取的用户信息
      console.log('用户信息:', response.data);
        this.userInfo = {
          userId: response.data.userId,
          nickname: response.data.userName,
          birthday: new Date(response.data.userBirthday),
          sex: response.data.userSex,
          phone: response.data.userPhone,
          email: response.data.userEmail,
          status: response.data.userStatus,
        };
        } else {
          console.error(`获取用户信息失败，状态码：${response.status}`);
          this.$message.error('获取用户信息失败');
        }
        //this.avatar = response.data.UserAvatar || 'https://via.placeholder.com/100'; // Assuming UserAvatar field
      } catch (error) {
        console.error('获取用户信息失败:', error);
        this.$message.error('获取用户信息失败');
      }
    },

    async updateUserInfo() {
      try {
        // 获取原始用户信息，用于填充空值
    //const originalInfo = await this.fetchUserInfo(this.userInfo.userId);
    console.log('啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊:', this.userInfo.userId); // 打印发送的数据
    console.log('啵啵啵啵啵啵啵啵啵啵啵啵:', this.userInfo.sex); // 打印发送的数据
    // 创建一个包含更新数据的对象，如果字段为空则使用原始数据
    const updatedInfo = {
      userId: this.userInfo.userId,
      userName: this.userInfo.nickname ,
      password: this.userInfo.password ,
      userEmail: this.userInfo.email ,
      userPhone: this.userInfo.phone ,
      userSex: this.userInfo.sex ,
      userAge: this.calculateAge(this.userInfo.birthday.toISOString()) ,
      userBirthday: this.userInfo.birthday ,
      userStatus: this.userInfo.status,
    };

        console.log('Sending updated user info:', this.userInfo.userId); // 打印发送的数据
        const response = await api.apiClient.put(`/api/users/updateInfo`, updatedInfo);
        if (response.status === 200) {
        this.$message.success('信息更新成功');
        console.log('ccccccccccccccccc:', this.userInfo); // 打印发送的数据
        } else {
          console.error(`信息更新失败，状态码：${response.status}`);
          this.$message.success('信息更新成功');
        }
      } catch (error) {
        if (error.response && error.response.status === 400) {
          this.$message.success('信息更新成功');
        } else {
          console.error('Failed to update user info:', error);
          this.$message.success('信息更新成功');
        }
      }
    },
    /*showChangeAvatarDialog() {
      this.changeAvatarDialogVisible = true;
    },
    */
    showChangePasswordDialog() {
      this.changePasswordDialogVisible = true;
    },
    showChangeEmailDialog() {
      this.changeEmailDialogVisible = true;
    },
    /*onAvatarChange(event: Event) {
      const target = event.target as HTMLInputElement;
      if (target.files) {
        this.newAvatar = target.files[0];
      }
    },
    
    async changeAvatar() {
      if (this.newAvatar) {
        const formData = new FormData();
        formData.append('avatar', this.newAvatar);

        try {
          await axios.post(`/api/users/${this.userId}/avatar`, formData, {
            headers: { 'Content-Type': 'multipart/form-data' },
          });
          this.$message.success('头像更新成功');
          this.changeAvatarDialogVisible = false;
        } catch (error) {
          console.error('Failed to change avatar:', error);
          this.$message.error('头像更新失败');
        }
      }
    },
      */
    
    async saveInfo() {
      await this.updateUserInfo();
    }
  },
  mounted() {
    const userId = localStorage.getItem('userId');
      // 处理获取到的用户信息
      // this.fetchUserInfo(userId);
      this.fetchUserInfo('001'); // 使用获取到的 userId
    }

    /*放在template中的修改头像部分
    1.修改密码上方：<div class="avatar-section">
            <img :src="avatar" alt="头像" class="avatar" />
            <el-button type="primary" @click="showChangeAvatarDialog">修改头像</el-button>
          </div>
    2.template最后
     <!-- 修改头像对话框-->
   <el-dialog title="修改头像" :visible.sync="changeAvatarDialogVisible">
      <input type="file" @change="onAvatarChange" />
      <span>请选择新的头像文件。</span>
      <div slot="footer" class="dialog-footer">
        <el-button @click="changeAvatarDialogVisible = false">取消</el-button>
        <el-button type="primary" @click="changeAvatar">确定</el-button>
      </div>
    </el-dialog>
    */ 
});
</script>

<style scoped>
.personal-info {
  display: flex;
  justify-content: center;
}
.info-container {
  display: flex;
  width: 100%;
}
.left-panel {
  flex: 1;
  display: flex;
  position:relative;
  top:20px;
  flex-direction: column;
  align-items: center;
  margin-right: 20px;
}
.avatar-section {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 20px;
}
.avatar {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  margin-bottom: 10px;
}
.right-panel {
  flex: 3;
}
</style>

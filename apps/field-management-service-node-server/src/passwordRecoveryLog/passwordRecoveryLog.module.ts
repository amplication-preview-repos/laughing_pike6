import { Module } from "@nestjs/common";
import { PasswordRecoveryLogModuleBase } from "./base/passwordRecoveryLog.module.base";
import { PasswordRecoveryLogService } from "./passwordRecoveryLog.service";
import { PasswordRecoveryLogController } from "./passwordRecoveryLog.controller";
import { PasswordRecoveryLogResolver } from "./passwordRecoveryLog.resolver";

@Module({
  imports: [PasswordRecoveryLogModuleBase],
  controllers: [PasswordRecoveryLogController],
  providers: [PasswordRecoveryLogService, PasswordRecoveryLogResolver],
  exports: [PasswordRecoveryLogService],
})
export class PasswordRecoveryLogModule {}

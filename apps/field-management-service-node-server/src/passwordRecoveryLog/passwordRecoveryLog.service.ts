import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { PasswordRecoveryLogServiceBase } from "./base/passwordRecoveryLog.service.base";

@Injectable()
export class PasswordRecoveryLogService extends PasswordRecoveryLogServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

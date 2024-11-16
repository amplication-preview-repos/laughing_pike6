import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { CompanySiteServiceBase } from "./base/companySite.service.base";

@Injectable()
export class CompanySiteService extends CompanySiteServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

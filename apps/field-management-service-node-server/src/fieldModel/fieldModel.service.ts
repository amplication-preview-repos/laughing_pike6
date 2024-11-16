import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { FieldModelServiceBase } from "./base/fieldModel.service.base";

@Injectable()
export class FieldModelService extends FieldModelServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}

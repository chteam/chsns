# Feature Specification: 私信系统

**Feature Branch**: `004-message-system`  
**Created**: 2025-11-13  
**Status**: Draft  
**Input**: 私信系统：发送接收私信、收件箱发件箱、消息已读未读状态、删除消息、消息搜索、支持HTML和纯文本消息

## User Scenarios & Testing *(mandatory)*

### User Story 1 - 发送私信 (Priority: P1)

用户可以向好友或其他用户发送一对一私信。支持纯文本和富文本（HTML）格式的消息内容。

**Why this priority**: 私信是社交网络中最基础的沟通方式，用户需要私密的一对一交流渠道。

**Independent Test**: 用户 A 选择用户 B，编写消息内容并发送，验证 B 在收件箱中收到该消息。

**Acceptance Scenarios**:

1. **Given** 用户在发私信页面, **When** 输入收件人用户名和消息内容并发送, **Then** 系统保存消息并通知收件人
2. **Given** 用户发送私信, **When** 消息内容超过 5000 字符, **Then** 系统提示"消息内容过长"并拒绝发送
3. **Given** 用户编辑消息, **When** 勾选"HTML 格式", **Then** 系统允许使用 HTML 标签（如 `<b>`, `<i>`, `<a>`）
4. **Given** 用户发送带 HTML 的消息, **When** 接收方查看, **Then** 系统渲染 HTML 格式并防止 XSS 攻击
5. **Given** 用户快速连续发送多条消息, **When** 超过速率限制（每分钟 10 条）, **Then** 系统提示"发送过于频繁"
6. **Given** 用户发送消息成功, **When** 消息已保存, **Then** 发件箱中立即显示该消息

---

### User Story 2 - 接收和查看私信 (Priority: P1)

用户可以在收件箱查看收到的所有私信，按时间倒序排列。未读消息有明显标识。

**Why this priority**: 用户需要及时查看和回复收到的消息，收件箱是消息管理的核心。

**Independent Test**: 用户 B 收到用户 A 的消息，登录后在收件箱看到未读消息标记，点击查看消息详情。

**Acceptance Scenarios**:

1. **Given** 用户访问收件箱, **When** 页面加载, **Then** 显示所有收到的消息（发件人、主题、时间、已读/未读状态）
2. **Given** 用户收到新消息, **When** 消息未读, **Then** 消息行显示粗体或高亮标识
3. **Given** 用户点击消息, **When** 打开消息详情, **Then** 系统标记消息为已读（IsSee=true）
4. **Given** 用户查看消息详情, **When** 页面加载, **Then** 显示完整内容、发件人信息、发送时间
5. **Given** 用户在消息详情页, **When** 点击"回复", **Then** 跳转到发私信页面并自动填充收件人和引用内容
6. **Given** 收件箱有多页消息, **When** 用户翻页, **Then** 每页显示 20 条消息

---

### User Story 3 - 管理发件箱 (Priority: P1)

用户可以查看自己发送的所有私信，包括发送时间和收件人。支持查看对方是否已读。

**Why this priority**: 用户需要查看自己的发送历史，确认消息是否送达和被阅读。

**Independent Test**: 用户 A 发送多条消息后，访问发件箱查看所有已发送消息，验证显示正确。

**Acceptance Scenarios**:

1. **Given** 用户访问发件箱, **When** 页面加载, **Then** 显示所有发送的消息（收件人、主题、时间）
2. **Given** 用户查看发件箱, **When** 消息已被对方阅读, **Then** 显示"已读"状态
3. **Given** 用户查看发件箱, **When** 消息未被阅读, **Then** 显示"未读"状态
4. **Given** 用户点击发件箱中的消息, **When** 打开详情, **Then** 显示完整消息内容和收件人信息
5. **Given** 用户在发件箱, **When** 消息被收件人删除, **Then** 发件箱仍显示该消息（独立删除）

---

### User Story 4 - 删除消息 (Priority: P1)

用户可以删除收件箱或发件箱中的消息。删除操作是单方面的，不影响对方的消息副本。

**Why this priority**: 用户需要清理不需要的消息，管理自己的消息列表。

**Independent Test**: 用户 A 删除收件箱中的一条消息，验证该消息在 A 的收件箱消失，但 B 的发件箱仍显示该消息。

**Acceptance Scenarios**:

1. **Given** 用户在收件箱, **When** 选择一条消息并点击"删除", **Then** 系统标记 IsToDel=true，消息从收件箱消失
2. **Given** 用户在发件箱, **When** 选择一条消息并点击"删除", **Then** 系统标记 IsFromDel=true，消息从发件箱消失
3. **Given** 用户删除消息, **When** 对方查看自己的消息箱, **Then** 对方仍能看到该消息（独立删除）
4. **Given** 用户批量选择消息, **When** 点击"批量删除", **Then** 系统删除所有选中的消息
5. **Given** 双方都删除同一条消息, **When** IsToDel=true 且 IsFromDel=true, **Then** 系统可以物理删除该记录（垃圾回收）
6. **Given** 用户误删消息, **When** 30 天内, **Then** 系统可以恢复已删除消息（可选功能）

---

### User Story 5 - 消息搜索 (Priority: P2)

用户可以在收件箱和发件箱中搜索消息，支持按发件人/收件人、标题、内容关键词搜索。

**Why this priority**: 当消息数量较多时，搜索功能帮助用户快速找到需要的消息。

**Independent Test**: 用户在收件箱搜索框输入关键词"会议"，验证返回所有标题或内容包含"会议"的消息。

**Acceptance Scenarios**:

1. **Given** 用户在收件箱搜索框输入关键词, **When** 按回车搜索, **Then** 系统返回匹配的消息列表
2. **Given** 用户搜索消息, **When** 输入发件人用户名, **Then** 系统返回该用户发送的所有消息
3. **Given** 用户搜索消息, **When** 搜索内容包含特殊字符, **Then** 系统正确转义并搜索
4. **Given** 用户搜索无结果, **When** 没有匹配的消息, **Then** 显示"未找到匹配的消息"
5. **Given** 用户搜索结果有多页, **When** 翻页查看, **Then** 保持搜索条件并分页显示

---

### User Story 6 - 消息通知 (Priority: P2)

用户收到新私信时，系统显示未读消息数量提醒。支持浏览器通知和站内通知。

**Why this priority**: 及时的消息通知提升用户响应速度和互动体验。

**Independent Test**: 用户 A 发送消息给 B，B 在导航栏看到红点提示"1 条新消息"。

**Acceptance Scenarios**:

1. **Given** 用户收到新消息, **When** 消息未读, **Then** 导航栏显示未读消息数量（如红点"3"）
2. **Given** 用户点击未读消息提示, **When** 跳转到收件箱, **Then** 显示所有未读消息
3. **Given** 用户收到新消息, **When** 浏览器支持通知, **Then** 弹出桌面通知（需用户授权）
4. **Given** 用户查看消息, **When** 消息标记为已读, **Then** 未读数量减少
5. **Given** 用户收到多条消息, **When** 全部标记为已读, **Then** 未读数量归零，红点消失

---

### Edge Cases

- **自己给自己发消息**: 系统应允许但需要提示确认（测试功能）
- **接收方账户被删除**: 发送消息应失败并提示"用户不存在"
- **并发发送**: 多个用户同时发送消息给同一用户，系统应正确保存所有消息
- **超长消息**: 用户通过工具绕过客户端验证发送超长消息，服务器应截断或拒绝
- **HTML 注入**: 用户发送恶意 HTML 代码（如 `<script>`），系统应过滤危险标签
- **消息丢失**: 网络中断导致消息发送失败，系统应允许重新发送
- **已读状态同步**: 用户在多个设备查看消息，已读状态应同步
- **删除冲突**: 用户在打开消息详情时，该消息被另一设备删除，应优雅处理

## Requirements *(mandatory)*

### Functional Requirements

#### 消息发送
- **FR-001**: 用户 MUST 能够向任何其他用户发送私信（非好友也可以，除非被屏蔽）
- **FR-002**: 私信 MUST 包含以下字段：标题（可选）、正文（必填）、发件人、收件人、发送时间
- **FR-003**: 消息标题 MUST 限制在 200 字符以内
- **FR-004**: 消息正文 MUST 限制在 5000 字符以内
- **FR-005**: 系统 MUST 支持纯文本和 HTML 两种消息格式（IsHtml 字段标识）
- **FR-006**: HTML 消息 MUST 过滤危险标签（`<script>`, `<iframe>`, `<object>` 等）
- **FR-007**: 系统 MUST 实施发送速率限制：每分钟最多 10 条，每天最多 200 条
- **FR-008**: 发送成功后系统 MUST 创建消息记录并更新发件箱

#### 消息接收
- **FR-009**: 用户 MUST 能够查看收到的所有消息（收件箱）
- **FR-010**: 收件箱 MUST 显示消息列表：发件人、标题、发送时间、已读/未读状态
- **FR-011**: 未读消息 MUST 有明显视觉标识（如粗体、高亮）
- **FR-012**: 用户打开消息详情时系统 MUST 自动标记为已读（IsSee=true）
- **FR-013**: 消息列表 MUST 按发送时间倒序排列（最新的在最前）
- **FR-014**: 收件箱 MUST 支持分页，每页 20 条消息

#### 发件箱
- **FR-015**: 用户 MUST 能够查看发送的所有消息（发件箱）
- **FR-016**: 发件箱 MUST 显示消息列表：收件人、标题、发送时间、对方已读状态
- **FR-017**: 系统 MUST 根据 IsSee 字段显示对方是否已读消息
- **FR-018**: 发件箱消息列表 MUST 支持分页

#### 消息删除
- **FR-019**: 用户 MUST 能够删除收件箱中的消息（标记 IsToDel=true）
- **FR-020**: 用户 MUST 能够删除发件箱中的消息（标记 IsFromDel=true）
- **FR-021**: 删除操作 MUST 是单方面的，不影响对方的消息副本
- **FR-022**: 用户 MUST 能够批量选择并删除多条消息
- **FR-023**: 系统 SHOULD 在双方都删除时物理删除记录（IsToDel=true 且 IsFromDel=true）
- **FR-024**: 删除操作 MUST 需要用户确认（防止误删）

#### 消息搜索
- **FR-025**: 用户 MUST 能够在收件箱和发件箱中搜索消息
- **FR-026**: 搜索 MUST 支持按标题、正文内容、发件人/收件人用户名查询
- **FR-027**: 搜索 MUST 支持模糊匹配（LIKE 查询）
- **FR-028**: 搜索结果 MUST 高亮显示匹配的关键词
- **FR-029**: 搜索结果 MUST 支持分页

#### 消息通知
- **FR-030**: 系统 MUST 实时统计用户的未读消息数量
- **FR-031**: 导航栏 MUST 显示未读消息数量（红点提示）
- **FR-032**: 用户 MUST 能够点击通知跳转到收件箱
- **FR-033**: 系统 SHOULD 支持浏览器桌面通知（需用户授权）
- **FR-034**: 消息标记为已读后 MUST 立即更新未读数量

#### 隐私与安全
- **FR-035**: 用户 MUST 能够屏蔽特定用户，屏蔽后无法收到该用户的消息
- **FR-036**: 系统 MUST 记录消息发送的 IP 地址和时间戳（安全审计）
- **FR-037**: HTML 消息 MUST 使用白名单过滤，仅允许安全标签（`<b>`, `<i>`, `<u>`, `<a>`, `<p>`, `<br>`）
- **FR-038**: 消息内容 MUST 不被搜索引擎索引（私密性）
- **FR-039**: 用户 MUST 能够报告垃圾消息或骚扰消息

### Key Entities

#### Message (私信实体)
- **Id** (long, 主键): 消息 ID
- **FromId** (long, 外键): 发件人用户 ID
- **ToId** (long, 外键): 收件人用户 ID
- **Title** (string, 200字符): 消息标题（可选）
- **Body** (string, 5000字符): 消息正文
- **SendTime** (DateTime): 发送时间
- **IsSee** (bool): 收件人是否已读（false=未读, true=已读）
- **IsFromDel** (bool): 发件人是否删除（false=未删除, true=已删除）
- **IsToDel** (bool): 收件人是否删除（false=未删除, true=已删除）
- **IsHtml** (bool): 是否为 HTML 格式（false=纯文本, true=HTML）
- **索引**: (ToId, IsToDel, SendTime) 用于收件箱查询
- **索引**: (FromId, IsFromDel, SendTime) 用于发件箱查询

#### MessageNotification (消息通知)
- **UserId** (long, 主键): 用户 ID
- **UnreadCount** (int): 未读消息数量
- **LastMessageTime** (DateTime): 最新消息时间
- **LastMessageFrom** (long, 外键): 最新消息发件人 ID
- **UpdatedAt** (DateTime): 更新时间

#### BlockList (屏蔽列表 - 可选扩展)
- **Id** (long, 主键): 记录 ID
- **UserId** (long, 外键): 用户 ID
- **BlockedUserId** (long, 外键): 被屏蔽的用户 ID
- **Reason** (string, 可选): 屏蔽原因
- **CreatedAt** (DateTime): 屏蔽时间

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 用户可以在 10 秒内完成发送一条私信（包括编辑内容）
- **SC-002**: 收件箱在 1 秒内加载完成（100 条消息）
- **SC-003**: 消息搜索在 500 毫秒内返回结果（1000 条消息）
- **SC-004**: 系统支持 5000 个并发消息发送不出现丢失
- **SC-005**: 未读消息数量实时更新，延迟 < 3 秒
- **SC-006**: HTML 过滤准确率 100%，无 XSS 漏洞
- **SC-007**: 消息发送成功率 > 99.9%（排除网络故障）
- **SC-008**: 用户使用私信功能后，留存率提升 30%
- **SC-009**: 消息已读状态同步延迟 < 5 秒
- **SC-010**: 批量删除 100 条消息在 3 秒内完成

## Assumptions *(optional)*

### Technical Assumptions
- 消息内容存储在数据库文本字段中
- HTML 过滤使用白名单库（如 HtmlSanitizer）
- 未读消息数量使用缓存（Redis）提升性能
- 消息通知通过 WebSocket 或轮询实现

### Business Assumptions
- 用户平均每天发送 3-5 条私信
- 大部分消息是纯文本，HTML 消息占比 < 10%
- 用户不会频繁删除消息，消息保留期限较长

### User Experience Assumptions
- 用户期望消息即时送达
- 用户希望看到对方是否已读消息
- 用户需要搜索历史消息
- 用户希望消息内容私密且安全

## Dependencies *(optional)*

### Internal Dependencies
- **用户认证与授权系统 (#001)**: 提供用户身份验证
- **用户资料系统 (#002)**: 提供用户头像和用户名
- **好友系统 (#003)**: 可选，用于判断是否为好友（影响隐私设置）
- 通知系统（未来）: 集成消息通知

### External Dependencies
- **数据库**: 支持全文搜索或 LIKE 查询
- **HTML 过滤库**: 如 HtmlSanitizer for .NET
- **缓存服务**: Redis 用于未读数量统计

## Out of Scope *(optional)*

以下功能**不在**本次规格范围内：

- 群聊功能 - 属于群组系统
- 消息加密（端到端加密） - 属于安全增强功能
- 消息撤回（发送后撤回） - 属于扩展功能
- 消息定时发送 - 属于高级功能
- 消息草稿保存 - 属于用户体验优化
- 附件上传（图片、文件） - 属于扩展功能
- 消息表情回复 - 属于互动增强功能
- 消息已读回执通知（邮件提醒） - 属于通知系统

## Notes *(optional)*

### Security Considerations
- HTML 过滤必须严格，防止 XSS 攻击
- 消息内容不应暴露给搜索引擎（robots.txt）
- 速率限制防止垃圾消息和骚扰
- 审计日志记录所有消息发送行为

### Performance Considerations
- 收件箱查询使用复合索引（ToId, IsToDel, SendTime）
- 未读数量使用 Redis 缓存，避免频繁统计查询
- 消息列表分页减少数据传输量
- 搜索功能可以使用全文索引（如 PostgreSQL FTS, Elasticsearch）

### Scalability Considerations
- 消息表可以按时间分表（如按月）
- 历史消息可以归档到冷存储
- 消息发送可以使用消息队列异步处理

### User Experience Considerations
- 发送消息时提供实时反馈（加载动画）
- 消息列表支持无限滚动或分页
- 搜索结果高亮关键词提升可读性
- 未读消息数量实时更新增强互动感

### Open Questions for Future Iterations
- 是否需要支持语音消息或视频消息？
- 是否需要支持消息表情符号或贴纸？
- 是否需要支持消息已读回执的邮件通知？
- 是否需要支持消息导出功能（GDPR 合规）？
- 是否需要支持消息置顶功能？

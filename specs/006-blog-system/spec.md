# Feature Specification: 博客笔记系统

**Feature Branch**: `006-blog-system`  
**Created**: 2025-11-14  
**Status**: Draft  
**Input**: 博客笔记系统：发布博客文章、博客分类标签、博客评论、博客草稿自动保存、博客可见性设置、支持Markdown和富文本、博客搜索

## User Scenarios & Testing *(mandatory)*

### User Story 1 - 创建和发布博客 (Priority: P1)

用户可以创建博客文章，编辑标题和正文，发布后在个人主页和好友动态中显示。

**Why this priority**: 博客是内容创作的核心功能，用户需要表达想法、分享经验的平台。

**Independent Test**: 用户点击"写博客"按钮，编辑标题和正文，点击"发布"，验证博客出现在个人主页和好友 Feed 中。

**Acceptance Scenarios**:

1. **Given** 用户在博客编辑页面, **When** 输入标题和正文并点击"发布", **Then** 博客保存并显示在个人主页
2. **Given** 用户发布博客, **When** 博客保存成功, **Then** 系统生成"发布博客"动态并通知好友
3. **Given** 用户发布博客, **When** 标题为空, **Then** 系统提示"标题不能为空"
4. **Given** 用户发布博客, **When** 正文超过 50000 字符, **Then** 系统提示"内容过长"
5. **Given** 用户发布博客, **When** 包含图片, **Then** 图片正确嵌入并显示
6. **Given** 用户发布博客后, **When** 访问博客详情页, **Then** 显示完整内容、作者、发布时间、分类标签

---

### User Story 2 - 博客编辑和删除 (Priority: P1)

用户可以编辑已发布的博客，修改标题、正文、分类等。也可以删除不需要的博客。

**Why this priority**: 用户需要修正错误或更新内容，删除过时或不想公开的博客。

**Independent Test**: 用户在个人博客列表点击"编辑"按钮，修改标题和正文，保存后验证更新生效。

**Acceptance Scenarios**:

1. **Given** 用户查看自己的博客, **When** 点击"编辑"按钮, **Then** 跳转到编辑页面并预填充内容
2. **Given** 用户编辑博客, **When** 修改标题或正文并保存, **Then** 博客更新并保留原发布时间
3. **Given** 用户编辑博客, **When** 修改分类标签, **Then** 博客在新分类下显示
4. **Given** 用户点击"删除博客", **When** 确认删除, **Then** 博客从列表中移除，关联动态同步删除
5. **Given** 用户删除博客, **When** 博客有评论, **Then** 系统提示"该博客有 N 条评论，确认删除？"
6. **Given** 用户误删博客, **When** 30 天内, **Then** 系统可以从回收站恢复（可选功能）

---

### User Story 3 - 博客分类和标签 (Priority: P1)

用户可以为博客设置分类（如技术、生活、旅行）和标签（如 JavaScript、摄影），方便组织和检索。

**Why this priority**: 分类和标签帮助用户组织内容，读者也可以按兴趣浏览相关博客。

**Independent Test**: 用户发布博客时选择分类"技术"和标签"JavaScript, Vue"，验证博客在对应分类页面显示。

**Acceptance Scenarios**:

1. **Given** 用户发布博客, **When** 选择分类（单选）, **Then** 博客归属到该分类
2. **Given** 用户发布博客, **When** 添加多个标签（多选）, **Then** 博客关联到所有标签
3. **Given** 用户查看个人主页, **When** 点击分类筛选, **Then** 仅显示该分类下的博客
4. **Given** 用户点击标签, **When** 跳转到标签页面, **Then** 显示所有包含该标签的博客（全站）
5. **Given** 用户创建新分类, **When** 输入分类名称, **Then** 系统保存到分类列表（用户自定义或系统预设）
6. **Given** 用户输入标签, **When** 标签已存在, **Then** 系统自动补全建议（避免重复标签）

---

### User Story 4 - 博客草稿自动保存 (Priority: P2)

系统在用户编辑博客时自动保存草稿，防止内容丢失。用户可以随时恢复未完成的博客。

**Why this priority**: 自动保存提升用户体验，避免因网络问题或误操作导致内容丢失。

**Independent Test**: 用户编辑博客 5 分钟后关闭页面，重新打开编辑页面，验证草稿已保存。

**Acceptance Scenarios**:

1. **Given** 用户编辑博客, **When** 每 30 秒自动保存一次草稿, **Then** 草稿保存到服务器（不发布）
2. **Given** 用户关闭编辑页面, **When** 草稿已保存, **Then** 下次打开时提示"发现未完成的草稿，是否恢复？"
3. **Given** 用户发布博客, **When** 博客发布成功, **Then** 系统自动删除对应草稿
4. **Given** 用户有多个草稿, **When** 访问草稿箱, **Then** 显示所有未发布的草稿列表
5. **Given** 用户删除草稿, **When** 确认删除, **Then** 草稿从列表中移除
6. **Given** 用户网络中断, **When** 自动保存失败, **Then** 系统使用浏览器本地存储（localStorage）作为备份

---

### User Story 5 - 博客可见性设置 (Priority: P1)

用户可以为博客设置可见性（公开、仅好友、仅自己、密码保护），控制谁可以阅读。

**Why this priority**: 隐私控制是用户对内容管理的核心需求，不同内容有不同的分享需求。

**Independent Test**: 用户发布博客并设置"仅好友可见"，验证非好友无法访问该博客。

**Acceptance Scenarios**:

1. **Given** 用户发布博客, **When** 选择可见性"公开", **Then** 所有人可以访问（包括游客）
2. **Given** 用户发布博客, **When** 选择可见性"仅好友", **Then** 仅好友可以访问
3. **Given** 用户发布博客, **When** 选择可见性"仅自己", **Then** 仅作者本人可以访问（私密日记）
4. **Given** 用户发布博客, **When** 选择可见性"密码保护", **Then** 访问者需要输入正确密码才能查看
5. **Given** 非好友访问"仅好友"博客, **When** 尝试打开博客链接, **Then** 显示"无权限访问"
6. **Given** 用户修改已发布博客的可见性, **When** 从"公开"改为"仅好友", **Then** 非好友立即无法访问

---

### User Story 6 - 支持 Markdown 和富文本 (Priority: P1)

用户可以选择使用 Markdown 或富文本编辑器编写博客，支持代码高亮、图片、链接等格式。

**Why this priority**: 不同用户有不同的编辑习惯，Markdown 适合技术用户，富文本适合普通用户。

**Independent Test**: 用户在 Markdown 模式下输入 `## 标题` 和代码块，预览和发布后验证格式正确。

**Acceptance Scenarios**:

1. **Given** 用户创建博客, **When** 选择 Markdown 编辑器, **Then** 支持 Markdown 语法（标题、加粗、代码块等）
2. **Given** 用户编辑 Markdown, **When** 点击"预览", **Then** 实时渲染 HTML 格式
3. **Given** 用户创建博客, **When** 选择富文本编辑器, **Then** 提供工具栏（加粗、斜体、插入图片、链接等）
4. **Given** 用户插入代码块, **When** 选择语言（如 JavaScript）, **Then** 博客详情页显示代码高亮
5. **Given** 用户插入图片, **When** 上传或粘贴图片, **Then** 图片嵌入到博客内容中
6. **Given** 用户切换编辑器模式, **When** 从 Markdown 切换到富文本, **Then** 系统转换内容格式（可选，避免格式丢失）

---

### User Story 7 - 博客搜索 (Priority: P2)

用户可以在全站或个人博客中搜索关键词，快速找到相关文章。

**Why this priority**: 当博客数量增多时，搜索功能帮助用户快速定位需要的内容。

**Independent Test**: 用户在搜索框输入"Vue 3"，验证返回所有标题或正文包含"Vue 3"的博客。

**Acceptance Scenarios**:

1. **Given** 用户在全站搜索框输入关键词, **When** 按回车搜索, **Then** 返回匹配的博客列表（标题或正文）
2. **Given** 用户搜索博客, **When** 搜索结果有多页, **Then** 支持分页显示
3. **Given** 用户搜索结果, **When** 点击博客标题, **Then** 跳转到博客详情页
4. **Given** 用户搜索无结果, **When** 没有匹配的博客, **Then** 显示"未找到相关博客"
5. **Given** 用户在个人主页搜索, **When** 输入关键词, **Then** 仅搜索该用户的博客
6. **Given** 搜索结果包含"仅好友"博客, **When** 非好友搜索, **Then** 该博客不显示（隐私过滤）

---

### User Story 8 - 博客评论 (Priority: P2)

用户可以在博客下发表评论，与作者或其他读者互动。评论支持嵌套回复。

**Why this priority**: 评论是博客互动的核心，增强读者与作者的联系。

**Independent Test**: 用户在博客详情页发表评论，验证评论显示在博客下方，支持回复其他评论。

**Acceptance Scenarios**:

1. **Given** 用户查看博客, **When** 在评论框输入内容并发表, **Then** 评论显示在博客下方
2. **Given** 用户发表评论, **When** 评论内容超过 1000 字符, **Then** 系统提示"评论过长"
3. **Given** 用户点击"回复"按钮, **When** 输入回复内容, **Then** 评论显示"@被回复人: 回复内容"
4. **Given** 博客有 50+ 条评论, **When** 页面加载, **Then** 默认显示最新 20 条，其他可展开查看
5. **Given** 用户删除自己的评论, **When** 确认删除, **Then** 评论从博客中移除
6. **Given** 博客作者删除他人评论, **When** 确认删除, **Then** 评论被移除（管理权限）

---

### Edge Cases

- **博客标题重复**: 用户发布多篇同名博客，系统应允许（使用 ID 区分）
- **博客超长内容**: 用户通过工具绕过客户端验证发布超长博客，服务器应截断或拒绝
- **Markdown XSS**: 用户在 Markdown 中插入恶意脚本，系统应过滤危险标签
- **草稿冲突**: 用户在两个设备同时编辑同一博客，应保留最新草稿
- **分类删除**: 用户删除分类后，该分类下的博客应移动到"未分类"
- **标签合并**: 系统存在重复标签（如"javascript"和"JavaScript"），应支持合并
- **博客浏览计数**: 作者刷新自己的博客，浏览次数是否增加
- **密码保护博客**: 用户忘记博客密码，是否支持重置（作者可以修改密码）

## Requirements *(mandatory)*

### Functional Requirements

#### 博客创建和发布
- **FR-001**: 用户 MUST 能够创建新博客并编辑标题和正文
- **FR-002**: 博客标题 MUST 限制在 200 字符以内
- **FR-003**: 博客正文 MUST 限制在 50000 字符以内
- **FR-004**: 用户 MUST 能够为博客选择分类（单选）
- **FR-005**: 用户 MUST 能够为博客添加标签（多选，最多 10 个）
- **FR-006**: 用户 MUST 能够设置博客可见性（公开、仅好友、仅自己、密码保护）
- **FR-007**: 用户 MUST 能够选择编辑器模式（Markdown 或富文本）
- **FR-008**: 用户发布博客时系统 MUST 验证标题非空
- **FR-009**: 博客发布成功后 MUST 生成"发布博客"动态事件
- **FR-010**: 博客 MUST 记录发布时间、最后修改时间、浏览次数

#### 博客编辑和删除
- **FR-011**: 用户 MUST 能够编辑自己已发布的博客
- **FR-012**: 编辑博客时 MUST 保留原发布时间，更新最后修改时间
- **FR-013**: 用户 MUST 能够删除自己的博客
- **FR-014**: 删除博客时 MUST 同时删除关联的评论、点赞、动态事件
- **FR-015**: 系统 SHOULD 支持博客回收站，删除后 30 天内可恢复

#### 博客分类和标签
- **FR-016**: 系统 MUST 支持用户自定义博客分类
- **FR-017**: 系统 SHOULD 提供预设分类（如技术、生活、旅行、美食等）
- **FR-018**: 用户 MUST 能够查看所有分类列表
- **FR-019**: 点击分类 MUST 显示该分类下的所有博客（按时间倒序）
- **FR-020**: 系统 MUST 支持博客标签（Tag）
- **FR-021**: 标签 MUST 全站共享（所有用户的博客共用标签库）
- **FR-022**: 标签输入 SHOULD 支持自动补全（避免重复标签）
- **FR-023**: 点击标签 MUST 显示全站所有包含该标签的博客

#### 博客草稿
- **FR-024**: 系统 MUST 在用户编辑博客时自动保存草稿（每 30 秒一次）
- **FR-025**: 草稿 MUST 保存到服务器（避免浏览器清空缓存导致丢失）
- **FR-026**: 用户打开编辑页面时 MUST 检测是否有未完成的草稿并提示恢复
- **FR-027**: 用户 MUST 能够查看所有草稿列表（草稿箱）
- **FR-028**: 用户 MUST 能够删除草稿
- **FR-029**: 博客发布成功后 MUST 自动删除对应草稿
- **FR-030**: 系统 SHOULD 支持浏览器本地存储作为草稿备份（网络中断时）

#### 博客可见性
- **FR-031**: 博客可见性 MUST 支持四种级别：公开（Public）、仅好友（FriendsOnly）、仅自己（Private）、密码保护（Password）
- **FR-032**: 公开博客 MUST 允许所有人访问（包括游客）
- **FR-033**: 仅好友博客 MUST 仅允许好友访问
- **FR-034**: 仅自己博客 MUST 仅允许作者本人访问
- **FR-035**: 密码保护博客 MUST 要求访问者输入正确密码
- **FR-036**: 非授权用户访问受限博客时 MUST 显示"无权限访问"
- **FR-037**: 用户 MUST 能够修改已发布博客的可见性

#### 编辑器支持
- **FR-038**: 系统 MUST 支持 Markdown 编辑器
- **FR-039**: Markdown 编辑器 MUST 支持实时预览
- **FR-040**: Markdown MUST 支持常用语法（标题、加粗、斜体、链接、图片、代码块、列表、引用）
- **FR-041**: 系统 MUST 支持富文本（WYSIWYG）编辑器
- **FR-042**: 富文本编辑器 MUST 提供工具栏（加粗、斜体、下划线、插入图片、插入链接、代码块等）
- **FR-043**: 博客详情页 MUST 渲染 Markdown 为 HTML 格式
- **FR-044**: 代码块 MUST 支持语法高亮（如 JavaScript, Python, Java 等）
- **FR-045**: 用户 MUST 能够上传图片并嵌入到博客中
- **FR-046**: Markdown 和富文本 MUST 过滤危险 HTML 标签（防止 XSS）

#### 博客搜索
- **FR-047**: 用户 MUST 能够在全站搜索博客（按标题或正文）
- **FR-048**: 用户 MUST 能够在个人主页搜索自己的博客
- **FR-049**: 搜索 MUST 支持模糊匹配（LIKE 查询或全文搜索）
- **FR-050**: 搜索结果 MUST 过滤隐私受限的博客（仅显示有权限查看的博客）
- **FR-051**: 搜索结果 MUST 支持分页，每页显示 20 条
- **FR-052**: 搜索结果 SHOULD 高亮显示匹配的关键词

#### 博客评论
- **FR-053**: 用户 MUST 能够在博客下发表评论
- **FR-054**: 评论 MUST 限制在 1000 字符以内
- **FR-055**: 评论 MUST 支持嵌套回复（@用户名）
- **FR-056**: 评论 MUST 显示评论人头像、用户名、时间
- **FR-057**: 用户 MUST 能够删除自己的评论
- **FR-058**: 博客作者 MUST 能够删除自己博客下的任何评论
- **FR-059**: 评论列表 MUST 按时间正序排列（最早的在最前）
- **FR-060**: 评论 SHOULD 支持分页，默认显示最新 20 条

#### 博客统计
- **FR-061**: 博客 MUST 记录浏览次数（每次访问 +1）
- **FR-062**: 博客 MUST 记录评论数量（冗余字段，性能优化）
- **FR-063**: 博客 SHOULD 记录点赞数量（如果支持点赞功能）
- **FR-064**: 用户 MUST 能够查看博客的浏览次数

### Key Entities

#### Blog (博客实体)
- **Id** (long, 主键): 博客 ID
- **UserId** (long, 外键): 作者用户 ID
- **Title** (string, 200字符): 博客标题
- **Body** (text): 博客正文内容
- **Summary** (string, 500字符): 博客摘要（自动提取或用户填写）
- **CategoryId** (long, 外键, 可选): 分类 ID
- **Visibility** (enum): 可见性（Public=0, FriendsOnly=1, Private=2, Password=3）
- **Password** (string, 可选): 密码保护的密码（加密存储）
- **IsMarkdown** (bool): 是否为 Markdown 格式（false=富文本, true=Markdown）
- **CreateTime** (DateTime): 发布时间
- **UpdateTime** (DateTime): 最后修改时间
- **ViewCount** (int): 浏览次数
- **CommentCount** (int): 评论数量（冗余字段）
- **索引**: (UserId, CreateTime) 用于个人博客列表查询
- **索引**: (CreateTime, Visibility) 用于全站博客查询
- **全文索引**: (Title, Body) 用于搜索功能

#### Category (分类实体)
- **Id** (long, 主键): 分类 ID
- **UserId** (long, 外键, 可选): 用户 ID（用户自定义分类）或 NULL（系统预设分类）
- **Name** (string, 50字符): 分类名称
- **Description** (string, 200字符, 可选): 分类描述
- **CreateTime** (DateTime): 创建时间

#### Tag (标签实体)
- **Id** (long, 主键): 标签 ID
- **Name** (string, 50字符): 标签名称
- **UseCount** (int): 使用次数（冗余字段，用于热门标签）
- **CreateTime** (DateTime): 创建时间
- **唯一索引**: (Name) 防止重复标签

#### BlogTag (博客-标签关联表)
- **BlogId** (long, 外键): 博客 ID
- **TagId** (long, 外键): 标签 ID
- **联合主键**: (BlogId, TagId)

#### BlogDraft (博客草稿实体)
- **Id** (long, 主键): 草稿 ID
- **UserId** (long, 外键): 用户 ID
- **Title** (string, 200字符): 草稿标题
- **Body** (text): 草稿正文
- **CategoryId** (long, 可选): 分类 ID
- **IsMarkdown** (bool): 是否为 Markdown
- **SaveTime** (DateTime): 保存时间
- **索引**: (UserId, SaveTime) 用于草稿列表查询

#### Comment (评论实体 - 复用或独立)
- **Id** (long, 主键): 评论 ID
- **BlogId** (long, 外键): 博客 ID
- **UserId** (long, 外键): 评论用户 ID
- **Content** (string, 1000字符): 评论内容
- **ReplyToId** (long, 可选): 回复的评论 ID
- **ReplyToUserId** (long, 可选): 回复的用户 ID
- **CreateTime** (DateTime): 评论时间
- **索引**: (BlogId, CreateTime) 用于评论列表查询

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 博客发布操作在 1 秒内完成（包括保存和生成动态）
- **SC-002**: 博客列表在 500 毫秒内加载完成（50 篇博客）
- **SC-003**: 博客搜索在 1 秒内返回结果（1000 篇博客）
- **SC-004**: Markdown 预览实时渲染，延迟 < 200 毫秒
- **SC-005**: 草稿自动保存成功率 > 99%（排除网络故障）
- **SC-006**: 博客可见性过滤准确率 100%（非授权用户无法访问）
- **SC-007**: 用户发布博客后，30% 以上的博客有评论互动
- **SC-008**: 用户平均每月发布 5 篇以上博客
- **SC-009**: 博客浏览次数增长率 > 20%（相比上线前）
- **SC-010**: Markdown 和富文本编辑器的采用率各占 50%

## Assumptions *(optional)*

### Technical Assumptions
- 博客内容存储在数据库 TEXT 字段中
- Markdown 渲染使用前端库（如 marked.js）
- 富文本编辑器使用现代库（如 Quill, TinyMCE）
- 代码高亮使用前端库（如 Prism.js, highlight.js）
- 草稿自动保存使用定时器（JavaScript setInterval）
- 博客搜索使用数据库全文索引或 Elasticsearch

### Business Assumptions
- 用户平均每月发布 5 篇博客
- 大部分用户选择"公开"可见性（占比 70%）
- Markdown 用户主要是技术类博客作者
- 富文本用户主要是非技术类博客作者
- 博客内容主要是文字，图片占比 < 20%

### User Experience Assumptions
- 用户期望编辑器操作流畅（无卡顿）
- 用户希望草稿自动保存（不需要手动保存）
- 用户希望博客支持代码高亮和图片嵌入
- 用户希望控制博客的隐私（不是所有博客都公开）

## Dependencies *(optional)*

### Internal Dependencies
- **用户认证与授权系统 (#001)**: 提供用户身份验证
- **用户资料系统 (#002)**: 提供用户头像和用户名
- **好友系统 (#003)**: 提供好友关系数据（可见性过滤）
- **活动动态系统 (#005)**: 生成"发布博客"动态事件
- **评论系统 (#008)**: 复用评论实体和逻辑（或独立实现）
- 通知系统（未来）: 集成博客评论通知

### External Dependencies
- **文件上传服务**: 支持图片上传（与 #012 上传模块集成）
- **Markdown 渲染库**: 前端使用 marked.js 或 markdown-it
- **富文本编辑器**: 前端使用 Quill 或 TinyMCE
- **代码高亮库**: 前端使用 Prism.js 或 highlight.js
- **数据库全文搜索**: PostgreSQL FTS 或 Elasticsearch

## Out of Scope *(optional)*

以下功能**不在**本次规格范围内：

- 博客多人协作编辑 - 属于高级功能
- 博客版本历史（查看历史修改记录） - 属于扩展功能
- 博客导出（PDF, Markdown 文件） - 属于工具功能
- 博客订阅（RSS Feed） - 属于集成功能
- 博客收藏功能（其他用户收藏我的博客） - 属于社交功能
- 博客打赏或付费阅读 - 属于商业功能
- 博客 SEO 优化（sitemap, meta 标签） - 属于推广功能
- 博客统计分析（访问来源、用户画像） - 属于数据分析

## Notes *(optional)*

### Security Considerations
- Markdown 和富文本必须过滤危险 HTML 标签（防止 XSS）
- 博客可见性过滤必须在数据库查询层实现
- 密码保护的博客密码必须加密存储（不能明文）
- 草稿自动保存需要防止 CSRF 攻击

### Performance Considerations
- 博客列表查询使用复合索引（UserId, CreateTime）
- 博客搜索使用全文索引（PostgreSQL FTS）
- 博客浏览次数使用异步更新（避免阻塞查询）
- 草稿自动保存使用防抖（debounce）减少请求频率
- 评论数量使用冗余字段（实时更新或定时同步）

### Scalability Considerations
- 博客表按时间分表（如按年）
- 历史博客可以归档到冷存储
- 博客搜索可以使用 Elasticsearch（高并发场景）
- 草稿表定期清理（超过 30 天未更新的草稿）

### User Experience Considerations
- 编辑器支持快捷键（Ctrl+B 加粗，Ctrl+S 保存）
- Markdown 预览支持实时渲染（延迟 < 200ms）
- 富文本编辑器支持拖拽上传图片
- 博客列表支持无限滚动或分页
- 草稿恢复提示友好（避免覆盖用户正在编辑的内容）

### Open Questions for Future Iterations
- 是否需要支持博客多人协作编辑？
- 是否需要博客版本历史功能？
- 是否需要支持博客导出（PDF, Markdown）？
- 是否需要支持 RSS Feed 订阅？
- 是否需要博客打赏或付费阅读功能？
- 草稿自动保存的频率是否需要用户可配置？
